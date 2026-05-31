using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class ChangeVehicleState
    {
        public static void Change(VehicleHandler i_VehicleHandler)
        {
            Console.WriteLine("Please enter a vehicle's license number: ");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter the new vehicle's state (1. Under repair 2. Repaired 3. Paid): ");
            string newVehicleState = Console.ReadLine();
            if (!eVehicleState.TryParse(newVehicleState, out eVehicleState o_newState))
            {
                throw new ArgumentException("No such vehicle state!");
            }
            i_VehicleHandler.ChangeVehicleState(licenseNumber, o_newState);
        }
    }
}
