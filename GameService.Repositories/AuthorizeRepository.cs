using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using GameService.Entities;
using Checkers.Entities;

namespace GameService.Repositories
{
    public class AuthorizeRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["gameservicedb"].ConnectionString;

        public int CreateGamer(string login, string email, string hashPassword)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (!IsExistEmptyGame(login, email))
                {
                    int result = 0;
                    var isGamer = conn.Execute("INSERT INTO gamers ( login, email, hashPassword) VALUES(@login, @email, @hashPassword)", new { login, email, hashPassword });
                    if (isGamer > 0)
                    {
                        var sql = @"SELECT idGamer FROM [gamers] 
                        WHERE email = @email";
                        result = conn.Query<int>(sql, new { email }).FirstOrDefault();

                    }
                    return result > 0 ? result : -1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int CreateGamer(Gamer gamer)
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    if (!IsExistGamer(gamer.Authentication, gamer.SocialId))
                    {
                        var isGamer = conn.Execute("INSERT INTO gamers(authentication, socialId, imageSource, firstName, lastName, city, login, email, hashPassword) VALUES(@Authentication, @SocialId, @ImageSource, @FirstName, @LastName, @City, @Login, @Email, @HashPassword)", new { gamer.Authentication, gamer.SocialId, gamer.ImageSource, gamer.FirstName, gamer.LastName, gamer.City, gamer.Login, gamer.Email, gamer.HashPassword });
                        if (isGamer <= 0) return -1;
                    }
                    var sql = @"SELECT idGamer FROM [gamers] 
                        WHERE authentication = @Authentication AND socialId = @SocialId";
                    int result = conn.Query<int>(sql, new { gamer.Authentication, gamer.SocialId }).FirstOrDefault();
                    return result;
                }
            }
            catch { return -1; }
        }

        public bool IsExistEmptyGame(string login, string email)
        {
            var sql = @"SELECT * FROM [gamers] 
                        WHERE login = @login OR email = @email";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var game = conn.Query(sql, new { login, email }).FirstOrDefault();
                return game != null ? true : false;
            }
        }

        public bool IsExistGamer(string authentication, long socialId)
        {
            var sql = @"SELECT * FROM [gamers] 
                        WHERE authentication = @authentication AND socialId = @socialId";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var gamer = conn.Query(sql, new { authentication, socialId }).FirstOrDefault();
                return gamer != null ? true : false;
            }
        }
    }
}
