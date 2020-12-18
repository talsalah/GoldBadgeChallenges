using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepository
{
    public class BadgeRepo
    {
        private Dictionary<int, Badge> _DicofBadge = new Dictionary<int, Badge>();
        //List<string> doorName = new List<string>();
        //Badge badge = new Badge();

        // Create
        public void AddBadgeToDictionary(Badge badge)
        {
            _DicofBadge.Add(badge.BadgeID, badge);

        }



        //ADD


        public bool AddADoor(int badgeId, string doorNames)

        {
            Badge badge = GetKeyValuePair(badgeId);

            if (badge == null)
            {
                return false;
            }


            int orignailNumber = badge.DoorNames.Count;
            badge.DoorNames.Add(doorNames);

            if (orignailNumber < badge.DoorNames.Count)
            {
                return true;

            }
            else
            {
                return false;
            }
        }




        //Read
        public Dictionary<int, Badge> GetBadgeDictionary()
        {
            return _DicofBadge;

        }

        //




        //Delete 
        public bool RemoveADoor(int badgeId, string doorNames)

        {
            Badge badge = GetKeyValuePair(badgeId);

            if (badge == null)
            {
                return false;
            }


            int orignailNumber = badge.DoorNames.Count;
            badge.DoorNames.Remove(doorNames);

            if (orignailNumber > badge.DoorNames.Count)
            {
                return true;

            }
            else
            {
                return false;
            }
        }





        

        // Helper Method 
        public Badge GetKeyValuePair(int badgeID)
        {
            foreach (KeyValuePair<int, Badge> badge in _DicofBadge)
            {
                if (badge.Key == badgeID) 
                
                {
                    return badge.Value;
                }
            }

            return null;
        }


    }
}
