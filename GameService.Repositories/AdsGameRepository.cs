using GameService.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GameService.Repositories
{
    public class AdsGameRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["gameservicedb"].ConnectionString;
        public IEnumerable<AdsGame> GetAdsGames(string language)
        {
            try
            {
                var sql = @"SELECT AppId, Icon, Name FROM Description D
                            LEFT JOIN Games G ON G.GameId = D.GameId
                            WHERE D.Language LIKE @likeLanguage";
                using (var conn = new SqlConnection(ConnectionString))
                {
                    string likeLanguage = string.Format("%{0}%", language);
                    var games = conn.Query<AdsGame>(sql, new { likeLanguage });
                    return games;
                }
            }
            catch { return null; }
        }
    }
}
