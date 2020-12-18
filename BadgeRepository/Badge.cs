using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }


        public Badge() { }
        public Badge(int badgeId, List<string> doorNames)
        {
            BadgeID = badgeId;
            DoorNames = doorNames;

        }
    }
}
