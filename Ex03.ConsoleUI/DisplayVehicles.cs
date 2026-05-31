using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

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
            foreach(RegisteredVehicle vehicle in vehicleList)
            {
                PrintVehicle.LicenseNumber(vehicle);
            }
        }
    }
}