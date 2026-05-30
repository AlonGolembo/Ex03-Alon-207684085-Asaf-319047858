using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class MainMenu
    {
        public static void StartMenu()
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.WriteLine("Welcome to the garage managing system!");
                Console.WriteLine("Please choose one of the options below: ");
                Console.WriteLine("1. Load vehicles from the database");
                Console.WriteLine("2. Insert a new vehicle");
                Console.WriteLine("3. Display vehicles in the garage");
                Console.WriteLine("4. Change a vehicle state");
                Console.WriteLine("5. Fill up air in tiers");
                Console.WriteLine("6. Refuel");
                Console.WriteLine("7. Recharge");
                Console.WriteLine("8. Display vehicle's details");
                Console.WriteLine("9. Exit");
                try
                {
                    runMenu = UserInputDigest(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error]: {ex.Message}");
                    Console.WriteLine("Please try again!");
                }
            }
        }

        private static bool UserInputDigest(string i_UserInput)
        {
            if(!int.TryParse(i_UserInput, out int userChoice))
            {
                throw new FormatException("Can't parse user input!");
            }
            if (!(userChoice >= 1 && userChoice <= 9))
            {
                throw new ValueRangeExpection("Invalid choice number!");
            }

            bool continueToMenu = true;

            switch (userChoice)
            {
                case 1:
                    VehicleDatabaseLoader.Load(i_VehicleHandler, VehicleDB.Name());
                    break;
                case 2:
                    Console.WriteLine("Please Enter a vehicle's license number: ");
                    InsertVehicleToGarage.Insert(i_VehicleHandler, Console.ReadLine());
                    break;
                case 3:
                    DisplayVehicles.Display();
                    break;
                case 4:
                    Console.WriteLine("Please enter a vehicle's license number: ");
                    string licenseNumber = Console.ReadLine();
                    Console.WriteLine("Please enter the new vehicle's state: ");
                    string newVehicleState = Console.ReadLine();
                    VehicleChangeState.Change(licenseNumber, newVehicleState);
                    break;
                case 5:
                    Console.WriteLine("Please enter a vehicle's license number: ");
                    FillAir.Fill(Console.ReadLine());
                    break;
                case 6:
                    Console.WriteLine("Please enter a vehicle's license number: ");
                    Energize.Refuel(Console.ReadLine());
                    break;
                case 7:
                    Console.WriteLine("Please enter a vehicle's license number: ");
                    Energize.Recharge(Console.ReadLine());
                    break;
                case 8:
                    Console.WriteLine("Please enter a vehicle's license number: ");
                    PrintVehicle.Print(Console.Read());
                    break;
                case 9:
                    Console.WriteLine("Thank you for using the garage management system!");
                    Console.WriteLine("Hope to seet you again!");
                    continueToMenu = false;
                    break;
            }

            return continueToMenu;
        }
    }
}
