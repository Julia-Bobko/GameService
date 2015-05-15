using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Entities
{
    public class Gamer
    {
        public int GamerId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }

        public string ResetPassword { get; set; }
    }
}
