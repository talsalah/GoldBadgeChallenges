using KomodoClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomodoClaimsConsole
{
    public class ProgramUI
    {
        private FileClaimsRepo _itemRepo = new FileClaimsRepo();
        // private Queue<FileClaims> _claim = new Queue<FileClaims>();

        public void Run()
        {
            seedQueue();
            Menu();

        }
        private void Menu()
        {

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. See All Claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayAllClaims();

                        break;


                    case "2":
                        TakeCareOfNextClaim();
                        break;


                    case "3":
                        EnterANewClaim();
                        break;


                    case "4":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
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


        private void DisplayAllClaims()
        {
            Console.Clear();
            Queue<FileClaims> directory = _itemRepo.GetClaimList();
            Console.WriteLine($"Current number of claims are:{directory.Count()}");
            Console.WriteLine($" { "ClaimID",-25} { "Claim Type",-25} { "Description",-25} { "Amount",-12} { "Date of Incident",-25} { "DateOfClaim",-27}  { "Is claim Valid",-25} ");

            foreach (FileClaims claim in directory)
            {
                Console.WriteLine($"{claim.ClaimID,-25}{claim.TypeofClaim,-25}{claim.Description,-25}${claim.ClaimAmount,-25}{claim.DateofIncident.ToShortDateString(),-25}{claim.DateofClaim.ToShortDateString(),-32}{claim.IsValid,-25} ");

            }
            Console.WriteLine("Please press any key to continue...");
            Console.ReadLine();

        }


        private void TakeCareOfNextClaim()
        {
            FileClaims nextClaim = _itemRepo.GetClaimList().Peek();

            Console.WriteLine($"ClaimId:{nextClaim.ClaimID,-10}\nType:{nextClaim.TypeofClaim,-10}\nDescription:{nextClaim.Description,-10}\nAmount:${nextClaim.ClaimAmount,-10}\nDateofAccident:{nextClaim.DateofIncident,-25}\nDateofClaim:{nextClaim.DateofClaim,-32}\nIsValid:{nextClaim.IsValid,-25} ");
            Console.WriteLine("Do you want to deal with this claim now? (yes/no)");

            string dealYes = Console.ReadLine().ToLower();
            if (dealYes == "yes")
            {

                _itemRepo.GetClaimList().Dequeue();
                //newClaim.IsValid = true;
            }
            //else
            //{
            //    Console.WriteLine("Please press any key to continue...");
            //    Console.ReadKey();
            //}


        }



        private void EnterANewClaim()
        {

            //ClaimID
            Console.Clear();
            FileClaims newClaim = new FileClaims();

            Console.WriteLine(" Enter The ClaimID:");
            string starAsIntiger = Console.ReadLine();
            //int Idnumber;
            //Int32.TryParse(starAsIntiger, out Idnumber);
            newClaim.ClaimID = int.Parse(starAsIntiger);

            //Claim Type
            Console.WriteLine("Enter the Claim Type \n" +
            "1. Car\n" +
            "2. Home\n" +
            "3. Theft \n");

            string claimTypeAsString = Console.ReadLine();// take string description and Parse to int (to use the numbers)
            int claimTypeAsInt = int.Parse(claimTypeAsString);  // Pase description from string to Int
            newClaim.TypeofClaim = (ClaimType)claimTypeAsInt;  //Casting take one object and cast it to different type.

            // Description 
            Console.WriteLine("Enter the description for the Claim:");
            newClaim.Description = Console.ReadLine();

            // Claim Amount
            Console.WriteLine("Enter the Claim Amount:");
            string starsAsString = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(starsAsString);

            //Date of Accident

            Console.WriteLine("Date of Incident: ie:(mm/dd/yyyy)");
            newClaim.DateofIncident = DateTime.Parse(Console.ReadLine());



            //Console.WriteLine("TIME: {0}", value);

            Console.WriteLine("Date of Claim: ie:(mm/dd/yyyy)");
            newClaim.DateofClaim = DateTime.Parse(Console.ReadLine());

            // Date of Claim

            Console.WriteLine("Is this Claim Valid to proceed ? (True/False)");
            string validClaim = Console.ReadLine().ToLower();
            if (validClaim == "True")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }


            _itemRepo.AddClaimToList(newClaim);

        }





        private void seedQueue()
        {
            FileClaims Honda = new FileClaims(1, ClaimType.Car, "Car hit on i69", 4000.00, new DateTime(2020 , 07 , 02), new DateTime(2020 , 06 , 01), true);
            FileClaims House = new FileClaims(1, ClaimType.Home, "House fire in kitchen", 6000.00, new DateTime(2020 , 07 , 02), new DateTime(2020 , 06 , 01), true);
            FileClaims Theft = new FileClaims(1, ClaimType.Car, "Stolen pancakes", 10000.00, new DateTime(2020 , 08 , 12), new DateTime(2020 , 06 , 01), false);




            _itemRepo.AddClaimToList(Honda);
            _itemRepo.AddClaimToList(House);
            _itemRepo.AddClaimToList(Theft);

        }

    }
}