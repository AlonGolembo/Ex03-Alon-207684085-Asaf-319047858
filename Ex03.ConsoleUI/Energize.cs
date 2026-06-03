using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Energize
    {
        public static void Recharge(VehicleHandler i_VehicleHandler)
        {
            Console.WriteLine("Insert a license number to charge: ");
            string licenseNubmer = Console.ReadLine();
            Console.WriteLine("Insert amount of minutes to charge: ");
            //string minutesToCharge = Console.ReadLine(); -->> Needs to be deleted ?
            if (!float.TryParse(Console.ReadLine(), out float minutesToCharge))
            {
                throw new FormatException("Can't parse minutes to float!");
            }

            try
            {
                i_VehicleHandler.ChargeVehicle(licenseNubmer, minutesToCharge);
                Console.WriteLine("Vehicle was successfully recharged");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Recharge failed, please try again!");
            }
        }


        public static void Refuel(VehicleHandler i_VehicleHandler)
        {
            Console.WriteLine("Insert a license number to refuel: ");
            string licenseNubmer = Console.ReadLine();
            Console.WriteLine("Choose fuel type: ");
            Console.WriteLine("1. Soler");
            Console.WriteLine("2. Octan95");
            Console.WriteLine("3. Octan96");
            Console.WriteLine("4. Octan98");
            if(!eFuelType.TryParse(Console.ReadLine(), out eFuelType fuelType))
            {
                throw new FormatException("Can't parse fuel type!");
            }
            if(!Enum.IsDefined(typeof(eFuelType), fuelType))
            {
                throw new ArgumentException("Enum isn't defined!");
            }
            Console.WriteLine("Insert amount of liters to fill up: ");
            if(!float.TryParse(Console.ReadLine(), out float fuelLiters))
            {
                throw new FormatException("Can't parse fuel amount!");
            }

            try 
            {
                i_VehicleHandler.FuelVehicle(licenseNubmer, fuelType, fuelLiters);
                Console.WriteLine("Vehicle was successfully refuled");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Refuel failed, please try again!");
            }
                
        }
    }
}
