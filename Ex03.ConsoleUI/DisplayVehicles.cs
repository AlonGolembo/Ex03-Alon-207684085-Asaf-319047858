using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ex03.ConsoleUI
{
    internal class DisplayVehicles
    {
        internal static void DisplayAccordingToState(VehicleHandler i_VehicleHandler)
        {
            Console.WriteLine("Choose a vehicle state to display:");
            Console.WriteLine("1. Under repair");
            Console.WriteLine("2. Repaired");
            Console.WriteLine("3. Paid");

            string userInputString = Console.ReadLine();
            if (!eVehicleState.TryParse(userInputString, out eVehicleState o_NewState))
            {
                throw new FormatException("Can't parse value to enum!");
            }

            if (!Enum.IsDefined(typeof(eVehicleState), o_NewState))
            {
                throw new ArgumentException("Enum not defined!");
            }

            List<RegisteredVehicle> vehicleList = i_VehicleHandler.DisplayVehicles(o_NewState);
            int numberOfVehiclesInList = vehicleList.Count;

            if (numberOfVehiclesInList == 0)
            {
                Console.WriteLine("There are no cars in the garage in this state!");
            }
            else
            {
                if(numberOfVehiclesInList == 1)
                {
                    Console.WriteLine($"There is 1 vehicle in the garage in {o_NewState} state:");
                    PrintVehicle.LicenseNumber(vehicleList[0]);
                }
                else
                {
                    Console.WriteLine($"There are{numberOfVehiclesInList} vehicles in the garage in {o_NewState} state are:");
                    foreach (RegisteredVehicle vehicle in vehicleList)
                    {
                        PrintVehicle.LicenseNumber(vehicle);
                    }
                }
            }   
        }
    }
}