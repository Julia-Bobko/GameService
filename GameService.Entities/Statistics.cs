using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Entities
{
    public class Statistics
    {
        public int StatisticsId { get; set; }
        public string TitleGame { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public int Count { get; set; }
    }
}
