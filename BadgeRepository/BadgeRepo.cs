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


        //Read
        public Dictionary<int, Badge> GetBadgeDictionary()
        {
            return _DicofBadge;

        }

        //




        // Delete 
        /*public bool RemoveADoor(int badgeId)

        {

            if (badge.BadgeID != badgeId)
            {
                return false;
            }


            int orignailNumber = _DicofBadge.Count;
            _DicofBadge.Remove(badge.BadgeID);

            if (orignailNumber > _DicofBadge.Count)
            {
                return true;

            }
            else
            {
                return false;
            }
        }*/



        // Helper Method 
        public Dictionary<int, Badge> GetKeyValuePair(int badgeID)
        {
            foreach (Dictionary<int, Badge>  badge in _DicofBadge)
            {
               // if (badge.TryGetValue(badgeID,out badge.Values)) 
                    if(badge.Key==badgeID)
                {
                    return badge;
                }
            }

            return null;
        }


    }
}
