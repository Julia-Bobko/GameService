using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GameService.Entities;
using System.Xml.Linq;

namespace GameService.Repositories
{
    public class OnlineGameRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["gameservicedb"].ConnectionString;

        public bool CreateGame(string idFirstGamer)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (!IsExistEmptyGame(idFirstGamer))
                {
                    var result = conn.Execute("INSERT INTO [checkersGame](idFirstGamer) VALUES(@idFirstGamer)", new { idFirstGamer });
                    return result > 0 ? true : false;
                }
                else
                {
                    //var result = UpdateStatistics(userName, titleGame, count);
                    return false;
                }
            }
        }

        public bool IsExistEmptyGame(string idFirstGamer)
        {
            var sql = @"SELECT * FROM [checkersGame] 
                        WHERE idFirstGamer = @idFirstGamer AND idSecondGamer IS NULL";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var game = conn.Query(sql, new { idFirstGamer }).FirstOrDefault();
                return game != null ? true : false;
            }
        }

        public bool StartGame(string idGame, string idSecondGamer, string idCurrentGamer)
        {
            var sql = @"UPDATE [checkersGame] SET idSecondGamer = @idSecondGamer, idCurrentGamer = @idCurrentGamer, idGamerColorWhite = @idCurrentGamer WHERE idGame = @idGame";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var result = conn.Execute(sql, new { idSecondGamer, idCurrentGamer, idGame });
                return result > 0 ? true : false;             
            }
        }


        public  int GetIdFirstGamer(string idGame)
        {
            var sql = @"SELECT idFirstGamer FROM [checkersGame] 
                        WHERE idGame = @idGame";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var idFirstGamer = conn.Query<int>(sql, new { idGame }).FirstOrDefault();
                return idFirstGamer;
            }
        }

        public bool UpdateStatusGame(int idGame, int idGamer, string currentStatus, string lastMovedCheckers, string lastDeletedCheckers)
        {
            var sql = @"UPDATE [checkersGame] 
                            SET currentStatus = @currentStatus, lastMovedCheckers = @lastMovedCheckers, lastDeletedCheckers = @lastDeletedCheckers,
                                idCurrentGamer = ( SELECT CASE @idGamer 
                                                          WHEN idFirstGamer THEN idSecondGamer 
                                                          WHEN idSecondGamer THEN idFirstGamer
                                                          END
                                                  from [checkersGame]
                                                  where idGame = @idGame)
                       WHERE idGame = @idGame";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var result = conn.Execute(sql, new { idGame, idGamer, currentStatus, lastMovedCheckers, lastDeletedCheckers });
                return result > 0 ? true : false;
            }
        }

//        public FullStatusGame GetFullStatusGame(string idGame, string idGamer)
//        {
//            var sql = @"SELECT currentStatus, lastMovedCheckers, lastDeletedCheckers FROM [checkersGame] 
//                        WHERE idGame = @idGame AND idCurrentGamer = @idGamer";
//            using (var conn = new SqlConnection(ConnectionString))
//            {
//                var fullStatusGame = conn.Query<FullStatusGame>(sql, new { idGame, idGamer }).FirstOrDefault();
//                return fullStatusGame;
//            }
//        }

        public string GetFullStatusGame(string idGame, string idGamer)
        {
            var sql = @"SELECT currentStatus FROM [checkersGame] 
                        WHERE idGame = @idGame AND idCurrentGamer = @idGamer";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var currentStatus = conn.Query<string>(sql, new { idGame, idGamer }).FirstOrDefault();
                return currentStatus;
            }
        }

        public CurrentStatusGame GetCurrentStatusGame(string idGame)
        {
            var sql = @"SELECT currentStatus, idCurrentGamer, idGamerColorWhite FROM [checkersGame] 
                        WHERE idGame = @idGame";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var currentStatus = conn.Query<CurrentStatusGame>(sql, new { idGame }).FirstOrDefault();
                return currentStatus;
            }
        }


        public StatusGame GetStatusGame(string idGame, string idGamer)
        {
            var sql = @"SELECT lastMovedCheckers,lastDeletedCheckers, idWinner FROM [checkersGame] 
                        WHERE idGame = @idGame AND idCurrentGamer = @idGamer";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var statusGame = conn.Query<StatusGame>(sql, new { idGame, idGamer }).FirstOrDefault();
                return statusGame;
            }
        }


        //        public List<CheckersGame> GetGames(string userName, string online)
        //        {
        //            bool isCheckOnline = online == "1" ? true : false;
        //            string sqlOnline = isCheckOnline ? " AND G.lastOnline >= DATEADD(minute, -5, GETDATE()) " : String.Empty;
        //            var sql = String.Format(@"SELECT C.idGame, C.idFirstGamer, G.login, G.rating 
        //                        FROM checkersGame C 
        //                        INNER JOIN gamers G ON 
        //                            C.idFirstGamer = G.idGamer 
        //                        AND 
        //                            G.login LIKE '%{0}%' {1}
        //                        WHERE C.idSecondGamer IS NULL", userName == "0" ? String.Empty : userName, sqlOnline);
        //            using (var conn = new SqlConnection(ConnectionString))
        //            {
        //                var curretStatus = conn.Query<CheckersGame>(sql, new { userName }).ToList();
        //                return curretStatus;
        //            }
        //        }

        public List<CheckersGame> GetGames(string idCurrentGamer, string userName, string online)
        {
            bool isCheckOnline = online == "1" ? true : false;
            string sqlOnline = isCheckOnline ? " AND G.lastOnline >= DATEADD(minute, -5, GETDATE()) " : String.Empty;
            var sql = String.Format(@"SELECT C.idGame, C.idFirstGamer, G.login, G.rating 
                        FROM checkersGame C 
                        INNER JOIN gamers G ON 
                            C.idFirstGamer = G.idGamer 
                        AND 
                            G.login LIKE '%{0}%' {1}
                        WHERE 
                            C.idFirstGamer != {2} 
                        AND
                        C.idFirstGamer NOT  IN  ( SELECT distinct CASE  {2}
                                                                      WHEN idFirstGamer THEN idSecondGamer 
                                                                      WHEN idSecondGamer THEN idFirstGamer
                                                                      ELSE ''
                                                                  END
                                                 from checkersGame
                                                 WHERE
                                                      idWinner IS NULL   
                                                 AND  
                                                      idSecondGamer  IS NOT NULL )
                        AND 
                            C.idSecondGamer IS NULL", userName == "0" ? String.Empty : userName, sqlOnline, idCurrentGamer);
            using (var conn = new SqlConnection(ConnectionString))
            {
                var curretStatus = conn.Query<CheckersGame>(sql, new { userName }).ToList();
                return curretStatus;
            }
        }

        public List<CurrentGame> GetCurrentGames(string idCurrentGamer)
        {
            var sql = @" SELECT C.idGame, G.login, G.rating, G.idGamer FROM checkersGame C , gamers G 
                        WHERE C.idWinner IS NULL
                                                 AND
                                                       ((C.idFirstGamer = @idCurrentGamer AND G.idGamer = C.idSecondGamer) 
                                                    OR 
							                           (C.idSecondGamer = @idCurrentGamer AND G.idGamer = C.idFirstGamer) )
						                        AND (C.idFirstGamer IS NOT NULL AND C.idSecondGamer IS NOT NULL)";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var curretGames = conn.Query<CurrentGame>(sql, new { idCurrentGamer }).ToList();
                return curretGames;
            }
        }


        public InputGame CheckInputGame(string idFirstGamer)
        {
            var sql = String.Format(@"IF NOT EXISTS(SELECT * FROM [gameservicedb].[dbo].[checkersGame] 
                        WHERE idSecondGamer IS NULL AND idFirstGamer = {0})
                        BEGIN
                            SELECT TOP 1 idGame, idCurrentGamer FROM [gameservicedb].[dbo].[checkersGame] WHERE idFirstGamer = {0} ORDER BY idGame DESC
                        END else begin select '' end", idFirstGamer);
            using (var conn = new SqlConnection(ConnectionString))
            {
                var inputGame = conn.Query<InputGame>(sql).FirstOrDefault();
                return inputGame;
            }
        }

        public bool FinishGame(string idGame, string idWinner)
        {
            var sql = @"UPDATE [checkersGame] 
                            SET  idWinner = @idWinner, winnerScore = (SELECT CASE @idWinner
                                                          WHEN idFirstGamer THEN 2
                                                          WHEN idSecondGamer THEN 2
                                                          END
                                                  from [checkersGame]
                                                  where idGame = @idGame), 
                                               loserScore =   (SELECT CASE @idWinner
                                                          WHEN idFirstGamer THEN  -2
                                                          WHEN idSecondGamer THEN -2
                                                          END
                                                  from [checkersGame]
                                                  where idGame = @idGame)                             
                       WHERE idGame = @idGame";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var result = conn.Execute(sql, new { idGame, idWinner });
                return result > 0 ? true : false;
            }
        }
    }
}
