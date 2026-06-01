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
            if (!eVehicleState.TryParse(Console.ReadLine(), out eVehicleState o_newState))
            {
                throw new ArgumentException("No such vehicle state!");
            }

            List<RegisteredVehicle> vehicleList = i_VehicleHandler.DisplayVehicles(o_newState);
            int numberOfVehiclesInList = vehicleList.Count;

            if (numberOfVehiclesInList == 0)
            {
                Console.WriteLine("There are no cars in the garage in this state!");
            }
            else
            {
                if(numberOfVehiclesInList == 1)
                {
                    Console.WriteLine($"There is 1 vehicle in the garage in {o_newState} state:");
                    PrintVehicle.LicenseNumber(vehicleList[0]);
                }
                else
                {
                    Console.WriteLine($"There are{numberOfVehiclesInList} vehicles in the garage in {o_newState} state are:");
                    foreach (RegisteredVehicle vehicle in vehicleList)
                    {
                        PrintVehicle.LicenseNumber(vehicle);
                    }
                }
            }   
        }
    }
}