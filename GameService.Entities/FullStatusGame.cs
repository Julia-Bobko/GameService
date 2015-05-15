using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Entities
{
    public class FullStatusGame
    {
        public string CurrentStatus { set; get; }
        public string LastMovedCheckers { get; set; }
        public string LastDeletedCheckers { get; set; }
    }
}
