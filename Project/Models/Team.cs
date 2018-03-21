using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Team
    {
        public int PlayersId { get; set; }
        public string UserId { get; set; }


        public Player Player { get; set; }
        public AspNetUsers User { get; set; }
    }
}
