using KomodoCafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeConsole
{
    class ProgramUI
    {
        private MenuRepo _itemRepo = new MenuRepo();
        public void Run()
        {
            seedMenuList();
            Set();

        }
        // Menu// Set

        private void Set()
        {
            bool keepRunning = true;
            while (keepRunning)
            {



                // Display option to users

                Console.WriteLine("Slecet a menue option:\n" +
                    "1. View The Menu\n" +
                    "2. View Menu By Meal Name\n" +
                    "3. View Menu By Meal Number\n" +
                    "4. Creat New Menu\n" +
                    "5. Update Exisiting Menu\n" +
                    "6. Delete Exisiting Menu\n" +
                    "7. Exit\n");



                //Get users inputs
                string input = Console.ReadLine();// Whatever readline retunes it saves as input then compare 


                //Evalute users inputs

                switch (input) // We evaluting wwhatrever read line give us
                {
                    case "1":
                        DisplayItemsInTheMenu();
                        break;
                    case "2":
                        ViewItemInMenuByMealName();
                        break;
                    case "3":
                        ViewItemInMenuByMealNumber();
                        break;
                    case "4":
                        CreateNewMenu();
                        break;
                    case "5":
                        UpdateExisitingItemFromMenu();
                        break;
                    case "6":
                        DeleteExisitingItemFromMenu();
                        break;

                    case "7":
                        Console.WriteLine("Goodbuy!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;



                }


                Console.WriteLine("Please press any key to continue.....");
                Console.ReadLine();
                Console.Clear();
            }

        }

        private void DisplayItemsInTheMenu()
        {
            Console.Clear();

            List<Menu> listofItems = _itemRepo.GetMenuList();

            foreach (Menu item in listofItems)// for each Menu object I want to show something in the console
            {
                Console.WriteLine($"Meal Name:{item.MealName}\n" +
                    $"Meal Number:{item.MealNumber} \n" +
                    $"Meal Description:{item.Description}\n" +
                    $"Meal Ingredient:{item.Ingredients}\n" +
                    $"Meal Price:{item.Price}\n"
                    );


            }

        }

        private void ViewItemInMenuByMealName()
        {
            Console.Clear();
            // Prompt the user to input the name
            Console.WriteLine("Please Enter the Meal Name:");
            //Get user's input 
            string mealname = Console.ReadLine();

            // find that Meal
            Menu item = _itemRepo.GetItemByMealName(mealname);

            //Display the content
            if (item != null)
            {
                Console.WriteLine($"Meal Name:{item.MealName}\n" +
                    $"Meal Number:{item.MealNumber} \n" +
                    $"Meal Description:{item.Description}\n" +
                    $"Meal Ingredient:{item.Ingredients}\n" +
                    $"Meal Price:{item.Price}\n"
                    );

            }
            else
            {

                Console.WriteLine("No Meal Name found: Please enter Correct info:");
            }




        }

        private void ViewItemInMenuByMealNumber()
        {
            Console.Clear();
            //Menu newItem = new Menu();
            // Prompt the user to input the name
            Console.WriteLine("Please Enter the Meal Number:");

            string input = Console.ReadLine();
            int inputAsInt = int.Parse(input);
            //ewItem.MealNumber = int.Parse(inputAsInt);
            //Get user's input 
            // int mealnumber = Console.ReadLine();

            // find that Meal
            Menu item = _itemRepo.GetItemByMealNumber(inputAsInt);

            //Display the content
            if (item != null)
            //if (inputAsInt == item.MealNumber)
            {
                Console.WriteLine($"Meal Name:{item.MealName}\n" +
                    $"Meal Number:{item.MealNumber} \n" +
                    $"Meal Description:{item.Description}\n" +
                    $"Meal Ingredient:{item.Ingredients}\n" +
                    $"Meal Price:{item.Price}\n"
                    );

            }
            else
            {

                Console.WriteLine("No Meal Number found: Please enter Correct info:");
            }

            Console.ReadKey();


        }

        private void CreateNewMenu()
        {
            Console.Clear();
            Menu newItem = new Menu();

            //Meal Name
            Console.WriteLine("Enter the Meal Name: (MeatLoaf, Chicken Dumplins, Grilled Chicken Tender,Homestyle Chicken, chessesBurger");
            newItem.MealName = Console.ReadLine();


            // Meal Number

            Console.WriteLine("Enter the Meal Number (1,2,3,...)");
            string starAsIntiger = Console.ReadLine();
            //int Idnumber;
            //Int32.TryParse(starAsIntiger, out Idnumber);
            newItem.MealNumber = int.Parse(starAsIntiger);

            // Description
            Console.WriteLine("Enter the Meal Description :\n" +
     "1. Super Saving\n" +
     "2. Best for Two\n" +
     "3. Dinner Special \n" +
     "4. Our Signature \n" +
     "5. Most popular\n");

            string descriptionAsString = Console.ReadLine();// take string description and Parse to int (to use the numbers)
            int descriptionAsInt = int.Parse(descriptionAsString);  // Pase description from string to Int
            newItem.Description = (MealDiscription)descriptionAsInt;  //Casting take one object and cast it to different type.

            // Ingredients 

            Console.WriteLine("Enter the Meal Ingreadiet: ( Chicken, Beef, Carrot , Corn, Mash potato, buttermilk Biscuits,  ");
            newItem.Ingredients = Console.ReadLine();

            // Price 
            Console.WriteLine(" Enter the Meal price $10.59,$15.99..");
            string starsAsString = Console.ReadLine();
            newItem.Price = double.Parse(starsAsString);

            _itemRepo.AddItemsToMenu(newItem);


        }

        private void UpdateExisitingItemFromMenu()
        {
            DisplayItemsInTheMenu();

            Console.WriteLine("\n Enter the Meal Name want to Update:");

            string oldItem = Console.ReadLine();

            Menu newItem = new Menu();

            //Meal Name
            Console.WriteLine("Enter the Meal Name: (i.e, MeatLoaf, Chicken Dumplins, Grilled Chicken Tender,Homestyle Chicken, chessesBurger");
            newItem.MealName = Console.ReadLine();


            // Meal Number

            Console.WriteLine("Enter the Meal Number (1,2,3,...)");
            string starAsIntiger = Console.ReadLine();
            //int Idnumber;
            //Int32.TryParse(starAsIntiger, out Idnumber);
            newItem.MealNumber = int.Parse(starAsIntiger);

            // Description
            Console.WriteLine("Enter the Meal Description :\n" +
                "1. Super Saving\n" +
                "2. Best for Two\n" +
                "3. Dinner Special \n" +
                "4. Our Signature \n" +
                "5. Most popular\n");

            string descriptionAsString = Console.ReadLine();// take string description and Parse to int (to use the numbers)
            int descriptionAsInt = int.Parse(descriptionAsString);  // Pase description from string to Int
            newItem.Description = (MealDiscription)descriptionAsInt;  //Casting take one object and cast it to different type.

            // Ingredients 

            Console.WriteLine("Enter the Meal Ingreadiet: ( i.e, Chicken, Beef, Carrot , Corn, Mash potato, buttermilk Biscuits,  ");
            newItem.Ingredients = Console.ReadLine();

            // Price 
            Console.WriteLine(" Enter the Meal price $10.59,$15.99..");
            string starsAsString = Console.ReadLine();
            newItem.Price = double.Parse(starsAsString);

            // _itemRepo.UpdateExisitingItem(newItem);
            bool wasUpdated = _itemRepo.UpdateExisitingItem(oldItem, newItem);

            if (wasUpdated)
            {
                Console.WriteLine("The item was successfully updated");

            }
            else
            {
                Console.WriteLine("The content Could not be updated");
            }

        }




        private void DeleteExisitingItemFromMenu()

        {

            DisplayItemsInTheMenu();

            Console.WriteLine("\n Enter the Meal Name want to remove:");

            string input = Console.ReadLine(); //Capture the input
            bool wasDeleted = _itemRepo.RemoveItemFromList(input);  // Call the Delete method        


            if (wasDeleted)
            {
                Console.WriteLine("The item was successfully delted");

            }
            else
            {
                Console.WriteLine("The content Could not be deleted");
            }

            //_itemRepo.DeleteExisitingItem(newItem);


        }

        private void seedMenuList()
        {
            Menu meatLoaf = new Menu(1, "MeatLoaf", MealDiscription.SuperSaving, " Meatloaf with tomatoes, onions and green peppers", 10.99);
            Menu grilledChickenTender = new Menu(2, "GrilledChickenTender", MealDiscription.BestforTwo, " Marinated and grilled chicken tenders.", 11.99);
            Menu chickenDumplins = new Menu(3, "chickenDumplins", MealDiscription.DinnerSpecial, " Slow simmered Chicken, carrot", 14.99);
            Menu countryFriedSteak = new Menu(4, "countryFriedSteak", MealDiscription.Mostpopular, " USDA Choice steak fried and topped with Sawmill Gravy", 13.99);




            _itemRepo.AddItemsToMenu(meatLoaf);
            _itemRepo.AddItemsToMenu(grilledChickenTender);
            _itemRepo.AddItemsToMenu(chickenDumplins);
            _itemRepo.AddItemsToMenu(countryFriedSteak);




        }

    }
}
