using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Entities
{
    public class NewStatistics
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string Game { get; set; }
        public string UserInfo { get; set; }
        public double Progress { get; set; }
    }
}
