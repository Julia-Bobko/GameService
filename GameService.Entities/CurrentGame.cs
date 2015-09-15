using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Entities
{
    public class CurrentGame
    {
        public int IdGame { get; set; }
        public string Login { get; set; }
        public int Rating { get; set; }
        public int IdGamer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageSource { get; set; }
        public string City { get; set; }
    }
}
