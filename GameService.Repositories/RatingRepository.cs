using Dapper;
using GameService.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Repositories
{
    public class RatingRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["gameservicedb"].ConnectionString;

        private bool IsExistRating(int idGamer, string game)
        {
            var sql = @"SELECT * FROM [rating] 
                        WHERE idGamer = @IdGamer AND game = @game";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var gamer = conn.Query(sql, new { idGamer, game }).FirstOrDefault();
                return gamer != null ? true : false;
            }
        }

        public bool CreateRating(Rating rating)
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    if (!IsExistRating(rating.IdGamer, rating.Game))
                    {
                        int result = conn.Execute("INSERT INTO rating(idGamer, score, lastDate, additionalInfo, game) VALUES(@IdGamer, @Score, @LastDate, @AdditionalInfo, @Game)", new { rating.IdGamer, rating.Score, rating.LastDate, rating.AdditionalInfo, rating.Game });
                        return result <= 0 ? false : true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch { return false; }
        }

        public Rating GetRating(string idGamer, string game)
        {
            try
            {
                var sql = "SELECT * FROM [rating] WHERE idGamer = @idGamer AND game = @game";
                using (var conn = new SqlConnection(ConnectionString))
                {
                    Rating rating = conn.Query<Rating>(sql, new { idGamer, game }).FirstOrDefault();
                    return rating;
                }
            }
            catch { return null; }
        }

        public IEnumerable<Rating> GetRatings(string game)
        {
            try
            {
                var sql = "SELECT TOP 100 * FROM [rating] WHERE game = @game ORDER BY score DESC";
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var ratings = conn.Query<Rating>(sql, new { game });
                    return ratings;
                }
            }
            catch { return null; }
        }

        public bool UpdateRating(Rating rating)
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    int result = conn.Execute(@"UPDATE rating 
                                                SET score = @Score, lastDate = @LastDate, additionalInfo = @AdditionalInfo
                                                WHERE idGamer = @IdGamer AND game = @Game", new { rating.IdGamer, rating.Score, rating.LastDate, rating.AdditionalInfo, rating.Game });
                    return result <= 0 ? false : true;
                }
            }
            catch { return false; }
        }
    }
}
