using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class ChangeVehicleState
    {
        public static void Change(VehicleHandler i_VehicleHandler)
        {
            Console.WriteLine("Please enter a vehicle's license number: ");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter the new vehicle's state:");
            Console.WriteLine("1. Under repair");
            Console.WriteLine("2. Repaired");
            Console.WriteLine("3. Paid");
            if (!eVehicleState.TryParse(Console.ReadLine(), out eVehicleState o_newState))
            {
                throw new ArgumentException("No such vehicle state!");
            }
            if(!Enum.IsDefined(typeof(eVehicleState), o_newState))
            {
                throw new ArgumentException("Enum isn't defined!");
            }
            i_VehicleHandler.ChangeVehicleState(licenseNumber, o_newState);
            Console.WriteLine($"Vehicle number {licenseNumber} state was changed to {i_VehicleHandler.GetVehicle(licenseNumber).VehicleState}"); // This is written this way to verify the method actually works
        }
    }
}
