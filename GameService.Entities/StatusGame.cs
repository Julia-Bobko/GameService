using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Entities
{
   public class StatusGame
    {
        public string LastMovedCheckers { get; set; }
        public string LastDeletedCheckers { get; set; }
        public string IdWinner { get; set; }
    }
}
