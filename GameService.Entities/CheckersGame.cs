using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace GameService.Entities
{
    public class CheckersGame
    {
        public int IdGame { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Rating { get; set; }
        public int IdFirstGamer { get; set; }
        public string ImageSource { get; set; }
        public string City { get; set; }
    }
}
