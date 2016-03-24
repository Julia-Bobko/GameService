using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Entities
{
    public class Rating
    {
        public int IdRating { get; set; }
        public int IdGamer { get; set; }
        public int Score { get; set; }
        public DateTime LastDate { get; set; }
        public string AdditionalInfo { get; set; }
        public string Game { get; set; }
    }
}
