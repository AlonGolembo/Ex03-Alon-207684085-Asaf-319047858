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
        private VehicleHandler m_VehicleHandler;

        public VehicleHandler VehicleHandler
        {
            get { return m_VehicleHandler; }
            private set { m_VehicleHandler = value; }
        }
        public MainMenu()
        {
            m_VehicleHandler = new VehicleHandler();
        }

        public MainMenu(VehicleHandler i_VehicleHandler)
        {
            VehicleHandler = i_VehicleHandler;
        }
        public void StartMenu()
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.WriteLine("Welcome to the garage managing system!");
                Console.WriteLine();
                Console.WriteLine("Please choose one of the options below: ");
                Console.WriteLine("1. Load vehicles from the database");
                Console.WriteLine("2. Insert a new vehicle");
                Console.WriteLine("3. Display license numbers in garage according to vehicle state");
                Console.WriteLine("4. Change a vehicle state");
                Console.WriteLine("5. Fill up air in tiers");
                Console.WriteLine("6. Refuel");
                Console.WriteLine("7. Recharge");
                Console.WriteLine("8. Display vehicle's details");
                Console.WriteLine("9. Exit");
                Console.WriteLine();
                try
                {
                    runMenu = UserInputDigest(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error]: {ex.Message}");
                    Console.WriteLine("Please try again!");
                }

                if(runMenu == false)
                {
                    Console.WriteLine("Thank you for using the garage management system!");
                    Console.WriteLine("Hope to see you again soon!");
                }
            }
        }

        private bool UserInputDigest(string i_UserInput)
        {
            if(!int.TryParse(i_UserInput, out int userChoice))
            {
                throw new FormatException("Can't parse user input!");
            }
            if (!(userChoice >= 1 && userChoice <= 9))
            {
                throw new ValueRangeException(1f, 9f);
            }

            bool continueToMenu = true;

            switch (userChoice)
            {
                case 1:
                    VehicleDatabaseLoader.Load(VehicleHandler, VehicleDB.Name());
                    continueToMenu = CheckIfExitOrContinue();
                    break;
                case 2:
                    Console.WriteLine("Please Enter a vehicle's license number: ");
                    InsertVehicleToGarage.Insert(VehicleHandler, Console.ReadLine());
                    continueToMenu = CheckIfExitOrContinue();
                    break;
                case 3:
                    DisplayVehicles.DisplayAccordingToState(VehicleHandler);
                    continueToMenu = CheckIfExitOrContinue();
                    break;
                case 4:
                    ChangeVehicleState.Change(VehicleHandler);
                    continueToMenu = CheckIfExitOrContinue();
                    break;
                case 5:
                    FillAir.Fill(VehicleHandler);
                    continueToMenu = CheckIfExitOrContinue();
                    break;
                case 6:
                    Energize.Refuel(VehicleHandler);
                    continueToMenu = CheckIfExitOrContinue();
                    break;
                case 7:
                    Energize.Recharge(VehicleHandler);
                    continueToMenu = CheckIfExitOrContinue();
                    break;
                case 8:
                    PrintVehicle.GetVehicleFromUserAndPrint(VehicleHandler);
                    continueToMenu = CheckIfExitOrContinue();
                    break;
                case 9:
                    continueToMenu = false;
                    break;
            }

            return continueToMenu;
        }

        private bool CheckIfExitOrContinue()
        {
            bool continueToMenu = false;
            Console.WriteLine("Would you like to return to menu or exit?");
            Console.WriteLine("1. Return to menu");
            Console.WriteLine("2. Exit");
            if(!int.TryParse(Console.ReadLine(), out int o_UserChoice))
            {
                throw new FormatException("Can't parse user input!");
            }

            if(o_UserChoice == 1)
            {
                continueToMenu = true;
                Console.Clear();
            }
            else if(o_UserChoice == 2)
            {
                continueToMenu = false;
            }
            else
            {
                throw new ArgumentException("User choice isn't valid!");
            }

            return continueToMenu;
        }
    }
}
