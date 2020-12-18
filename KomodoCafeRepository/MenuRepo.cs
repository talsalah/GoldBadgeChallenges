using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeRepository
{
       
    public class MenuRepo

    {
        private List<Menu> _listOfMenu = new List<Menu>();

        //Create
        public void AddItemsToMenu(Menu item) // Add items to Menu // Taking in Menu (Class) Called Items (Object)// Not returning anything 
        {
            _listOfMenu.Add(item); // Add Items (Method) to List of Menu

        }



        //Read
        public List<Menu> GetMenuList() // Menu Object to return the lis of menu method 
        {
            return _listOfMenu;// 
        }


        //Update

        public bool UpdateExisitingItem(string originalMealName, Menu newItem)  // We need to know waht is our original content and what is the new content Two string Find the orginal meal name then Update
        {
            //Find the meal name
            Menu oldItem = GetItemByMealName(originalMealName);

            // Update the mealname
            if (oldItem != null)
            {
                oldItem.MealName = newItem.MealName;
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.Description = newItem.Description;
                oldItem.Ingredients = newItem.Ingredients;
                oldItem.Price = newItem.Price;
                return true;

            }
            else
            {
                return false;
            }    



        }


        //Delete 
        public bool RemoveItemFromList(string mealname)//passing  mealname string
        {
            Menu item = GetItemByMealName(mealname); //finding the item by mealname

            if (item == null)
            {

                return false;
            }

            int initialCount = _listOfMenu.Count; // Gets the number of elements contianed in the List
            _listOfMenu.Remove(item);

            if (initialCount > _listOfMenu.Count)
            {
                return true;

            }
            else
            {
                return false;
            }

        }


        //Helper method that gets the menu based on some parameters 
        public Menu GetItemByMealName(string mealname)// find the mealname in the List<Menu>

        {
            foreach (Menu item in _listOfMenu)  // Menu is an Object// I'm going to take the list of menu and itterate Through it for each item in the menu.  I'm going to call it item 
            {
                if (item.MealName.ToLower() == mealname.ToLower()) // if I found the item in the meal name then return it otherwise return null
                {
                    return item;
                }

            }
            return null;

        }
        public Menu GetItemByMealNumber(int mealnumber)// find the mealname in the List<Menu>

        {
            foreach (Menu item in _listOfMenu)  // Menu is an Object// I'm going to take the list of menu and itterate Through it for each item in the menu.  I'm going to call it item 
            {
                if (item.MealNumber == mealnumber) // if I found the item in the meal name then return it otherwise return null
                {
                    return item;
                }

            }
            return null;

        }
    }

}

