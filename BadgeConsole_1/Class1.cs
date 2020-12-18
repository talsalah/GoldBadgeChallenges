using BadgeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeConsole
{
    class ProgramUI
    {

        private BadgeRepo _itemRepo = new BadgeRepo();
        public void Run()
        {
            seedDictionary();
            Menu();
        }


        private void Menu()
        {

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security AAdmin, What would you like to do?\n" +
                    "1. Create a New Badge \n" +
                    "2. Update Doors on an Existing Badge \n" +
                    "3. Delete All Doors From an Exisiting Badge\n" +
                    "4. Show a List with all Badge numbers and Doors Access");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddABadge();

                        break;


                    case "2":
                        UpdateABadge();
                        break;


                    case "3":
                        // ShowAllBadges();
                        break;


                    case "4":
                        ShowAllBadges();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // ADD A Badge
        private void AddABadge()
        {

        }

        // Update A Badge
        private void UpdateABadge()
        {

        }

        //List all badges view
        private void ShowAllBadges()
        {
            Console.Clear();
            Dictionary<int,Badge> badgeDictionary = _itemRepo.GetBadgeDictionary();

            //foreach (KeyValuePair<int, List<string>> item in badgeDictionary)
            //{


            //    Console.WriteLine($"BadgeId:{item.Key}\n" +
            //        $"doorNames");

            //    foreach (string ele in item.Value)
            //    {
            //        Console.WriteLine(ele);
            //    }
            //}
        }


        public void seedDictionary()
        {
            Dictionary<int, string> numberNames = new Dictionary<int, string>();
            numberNames.Add(12345, "A7"); //adding key/value using the Add() method
            numberNames.Add(22345, "A1,A4,B1,B2");
            numberNames.Add(22345, "A4,A5");

        }
    }
}

