using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class CompareViewModel
    {
        public IEnumerable<Player> Player { get; set; }
        public IEnumerable<Player> Player2 { get; set; }
        public IEnumerable<Player> Player3 { get; set; }
        public IEnumerable<Player> Player4 { get; set; }
        public IEnumerable<Player> Player2display { get; set; }
        public IEnumerable<Player> Player3display { get; set; }
        public IEnumerable<Player> Player4display { get; set; }
        public IEnumerable<Team> Team { get; set; }
        public IEnumerable<AspNetUsers> AspNetUsers { get; set; }

    }
}
