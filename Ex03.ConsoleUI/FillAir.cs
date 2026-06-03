using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class FillAir
    {
        public static void Fill(VehicleHandler i_VehicleHandler)
        {
            Console.WriteLine("Insert license number to fill air: ");
            string licenseNumber = Console.ReadLine();
            if(i_VehicleHandler.GetVehicle(licenseNumber) == null)
            {
                throw new ArgumentNullException("License number doesn't exist in garage!");
            }

            try
            {
                i_VehicleHandler.FillAir(licenseNumber);
                Console.WriteLine("Tiers were successfully filled!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Tier fill up failed!");
            }
        }
    }
}