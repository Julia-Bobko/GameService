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
    public class StatisticsRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["gameservicedb"].ConnectionString;

        public bool CreateStatistics(string titleGame, string userName, string country, string count)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (!IsExistUserName(userName, titleGame))
                {
                    var result = conn.Execute("INSERT INTO [Statistics](TitleGame, UserName, Country, Count) VALUES(@titleGame, @userName, @country, @count)", new { titleGame, userName, country, count });
                    return result > 0 ? true : false;
                }
                else
                {
                    var result = UpdateStatistics(userName, titleGame, count);
                    return result;
                }
            }
        }

        public bool UpdateStatistics(string userName, string titleGame, string count)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var result = conn.Execute("UPDATE [Statistics] SET Count = @count WHERE TitleGame = @titleGame AND UserName = @userName", new { titleGame, userName, count });
                return result > 0 ? true : false;
            }
        }

        public bool DeleteStatistics(string userName, string titleGame)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var result = conn.Execute("DELETE FROM [Statistics] WHERE TitleGame = @titleGame AND UserName = @userName", new { titleGame, userName });
                return result > 0 ? true : false;
            }
        }

        public IEnumerable<Entities.Statistics> GetStatisticsCollection(string titleGame)
        {
            var sql = "SELECT * FROM [Statistics] WHERE TitleGame = @titleGame";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var statistics = conn.Query<Statistics>(sql, new { titleGame });
                return statistics;
            }
        }

        public Statistics GetStatistics(string userName, string titleGame)
        {
            var sql = @"SELECT * FROM [Statistics] 
                        WHERE UserName = @userName AND TitleGame = @titleGame";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var statistics = conn.Query<Statistics>(sql, new { userName, titleGame }).FirstOrDefault();
                return statistics;
            }
        }

        public bool IsExistUserName(string userName, string titleGame)
        {
            var sql = @"SELECT * FROM [Statistics] 
                        WHERE UserName = @userName AND TitleGame = @titleGame";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var statistics = conn.Query<Statistics>(sql, new { userName, titleGame }).FirstOrDefault();
                return statistics != null ? true : false;
            }
        }
    }
}
