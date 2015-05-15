using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Entities
{
    public class UpdateStatus
    {
        public int IdGame { set; get; }
        public int IdGamer { set; get; }
        public string XmlCurrentStatus { set; get; }
        public string LastMovedCheckers { get; set; }
        public string LastDeletedCheckers { get; set; }
    }
}
