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
        private Dictionary<int, Badge> _DicofBadge = new Dictionary<int, Badge>();
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

            Badge newItem = new Badge();
            List<string> door = new List<string>();

            Console.Clear();

            Console.WriteLine("What is the number on the badge:");
            string starAsIntiger = Console.ReadLine();
            newItem.BadgeID = int.Parse(starAsIntiger);



            bool keepRunning = true;
            while (keepRunning == true)
            {

                Console.WriteLine("List a door that it needs access to:");

                string nextDoor = Console.ReadLine();
                door.Add(nextDoor);
                newItem.DoorNames = door;

                Console.WriteLine("Any other doors(yes / no) ?");
                string dealYes = Console.ReadLine();


                if (dealYes == "yes")
                {
                    keepRunning = true;
                }
                else
                {
                    keepRunning = false;
                }

            }

            _DicofBadge.Add(newItem.BadgeID, newItem);
            _itemRepo.AddBadgeToDictionary(newItem);



            Console.ReadKey();



        }

        // Update A Badge
        private void UpdateABadge()
        {
            Badge updateItem = new Badge();


            Console.Clear();
            Console.WriteLine("What is the badge number to update");
            string starsAsString = Console.ReadLine();
            int badgeID = int.Parse(starsAsString);
            Badge badge = _itemRepo.GetKeyValuePair(badgeID);
            if (badge != null)
            {

                Console.WriteLine($"{badge.BadgeID}{" has access to doors "}{string.Join("/", badge.DoorNames)}");
                Console.WriteLine("What would you like to do?\n" +
                    "1. Remove A door\n" +
                    "2. Add a door \n");
                string input = Console.ReadLine();



                switch (input) // We evaluting wwhatrever read line give us
                {
                    case "1":
                        Console.WriteLine("Which door would you like to remove?");
                        string input2 = Console.ReadLine();
                        bool inforemove = _itemRepo.RemoveADoor(badgeID, input2);
                        if (inforemove == true)
                        {
                            Console.WriteLine("Door removed");
                            //Console.WriteLine($"{badge.BadgeID}{" has access to doors "}{string.Join("/", badge.DoorNames)}");
                            if (badge.DoorNames.Count == 0)
                            {
                                Console.WriteLine($"{badge.BadgeID} has access to no doors ");
                            }
                            else
                            {
                                Console.WriteLine($"{badge.BadgeID}{" has access to doors "}{string.Join("/", badge.DoorNames)}");

                            }

                        }
                        else
                        {
                            Console.WriteLine("door has not removed");
                        }



                        break;
                    case "2":
                        Console.WriteLine("Which door would you like to Add?");
                        string input3 = Console.ReadLine();
                        bool doorAdd = _itemRepo.AddADoor(badgeID, input3);


                        if (doorAdd == true)
                        {
                            Console.WriteLine("Door Added");
                            //Console.WriteLine($"{badge.BadgeID}{" has access to doors "}{string.Join("/", badge.DoorNames)}");
                            if (badge.DoorNames.Count == 0)
                            {
                                Console.WriteLine($"{badge.BadgeID} has access to no doors ");
                            }
                            else
                            {
                                Console.WriteLine($"{badge.BadgeID}{" has access to doors "}{string.Join("/", badge.DoorNames)}");

                            }

                        }
                        else
                        {
                            Console.WriteLine("door has not removed");
                        }

                        break;


                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;

                }
            }


            else
            {
                Console.WriteLine("Badge Id not found");
            }







        }




        //List all badges view
        private void ShowAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badge> badgeDictionary = _itemRepo.GetBadgeDictionary();

            foreach (KeyValuePair<int, Badge> item in badgeDictionary)
            {

                Console.WriteLine($"BadgeId:{item.Key}\t" +
                    $"doorNames");

                foreach (var ele in item.Value.DoorNames)
                {
                    Console.WriteLine(ele);
                    // Console.WriteLine("{0} and {1}", ele.Key, ele.Value);
                }
            }
        }


        public void seedDictionary()
        {
            Dictionary<int, Badge> numberNames = new Dictionary<int, Badge>();

            Badge badge1 = new Badge(12345, new List<string> { "A7" });
            _itemRepo.AddBadgeToDictionary(badge1);
            Badge badge2 = new Badge(22345, new List<string> { "A7,A4,B1,B2" });
            _itemRepo.AddBadgeToDictionary(badge2);
            Badge badge3 = new Badge(32345, new List<string> { "A4,A5" });
            _itemRepo.AddBadgeToDictionary(badge3);



        }
    }
}

