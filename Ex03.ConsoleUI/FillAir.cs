using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class FillAir
    {
        public static void Fill(VehicleHandler i_VehicleHandler)
        {
            Console.WriteLine("Insert license number to fill air: ");
            string licenseNumber = Console.ReadLine();
            if(i_VehicleHandler.GetVehicle(licenseNumber) == null)
            {
                throw new ArgumentNullException("License number doesn't exist in garage!");
            }

            i_VehicleHandler.FillAir(licenseNumber);
        }
    }
}