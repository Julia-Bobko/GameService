using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GameService.Entities;

namespace GameService.Repositories
{
    public class NewStatisticsRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["gameservicedb"].ConnectionString;
        public bool CreateStatistics(NewStatistics newStatistics)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (!IsExistUserName(newStatistics.UserId, newStatistics.Game))
                {
                var result = conn.Execute("INSERT INTO [NewStatistics](UserId, Game, UserInfo, Progress) VALUES(@UserId, @Game, @UserInfo, @Progress)", new { newStatistics.UserId, newStatistics.Game, newStatistics.UserInfo, newStatistics.Progress });
                return result > 0 ? true : false;
                }
                else
                {
                    var result = UpdateStatistics(newStatistics, false);
                    return result;
                }
            }
        }

        public bool UpdateStatistics(Entities.NewStatistics newStatistics, bool isUpdateProgress = true)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var result = conn.Execute(String.Format("UPDATE [NewStatistics] SET UserInfo = @UserInfo {0} WHERE UserId = @UserId AND Game = @Game", isUpdateProgress ? ", Progress = @Progress " : String.Empty), new { newStatistics.UserInfo, newStatistics.Progress, newStatistics.UserId, newStatistics.Game });
                return result > 0 ? true : false;
            }
        }

        public bool DeleteStatistics(string userId, string game)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var result = conn.Execute("DELETE FROM [NewStatistics] WHERE UserId = @userId AND Game = @game", new { userId, game });
                return result > 0 ? true : false;
            }
        }

        public IEnumerable<Entities.NewStatistics> GetStatisticsCollection(string game)
        {
            var sql = "SELECT TOP 100 * FROM [NewStatistics] WHERE Game = @game ORDER BY Progress DESC";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var statistics = conn.Query<NewStatistics>(sql, new { game });
                return statistics;
            }
        }

        public Entities.NewStatistics GetStatistics(string userId, string game)
        {
            var sql = @"SELECT * FROM [NewStatistics] 
                        WHERE UserId = @userId AND Game = @game";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var statistics = conn.Query<NewStatistics>(sql, new { userId, game }).FirstOrDefault();
                return statistics;
            }
        }

        public bool IsExistUserName(string userId, string game)
        {
            var sql = @"SELECT * FROM [NewStatistics] 
                        WHERE userId = @userId AND game = @game";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var statistics = conn.Query<NewStatistics>(sql, new { userId, game }).FirstOrDefault();
                return statistics != null ? true : false;
            }
        }

        public IEnumerable<Entities.NewStatistics> GetStatisticsCollectionByCity(string game, string city)
        {
            city = "%|" + city;
            var sql = @"SELECT TOP 100 * FROM [NewStatistics] 
                        WHERE 
                            Game = @game 
                        AND
                            UserInfo LIKE @city
                        ORDER BY Progress DESC";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var statistics = conn.Query<NewStatistics>(sql, new { game, city });
                return statistics;
            }
        }

        public IEnumerable<Entities.NewStatistics> GetStatisticsCollectionBySocial(string game, string social)
        {
            social = social + "%";
            var sql = @"SELECT * FROM [NewStatistics] 
                        WHERE 
                            Game = @game 
                        AND
                            UserId LIKE @social
                        ORDER BY Progress DESC";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var statistics = conn.Query<NewStatistics>(sql, new { game, social });
                return statistics;
            }
        }
    }
}
