using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class VehicleDatabaseLoader
    {
        public static void Load(string i_fileName)
        {
            string[] dbLines = File.ReadAllLines(i_fileName);
            foreach (string dbLine in dbLines)
            {
                try
                {
                    Vehicle currentVehicle = ParseLine(dbLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        private static Vehicle ParseLine(string i_Line)
        {
            
            string[] lineDetails = i_Line.Split(',');
            if (!IsVehicleType(lineDetails[0]) || !IsLicenseId(lineDetails[1]))
            {
                throw new FormatException($"Line '{i_Line}' isn't a valid vehicle!");
            }

            return VehicleCreator.CreateVehicle(lineDetails[0], lineDetails[1], lineDetails[2]);
        }

        private static bool IsVehicleType(string i_VehicleType)
        {
            return i_VehicleType == "FuelCar" || i_VehicleType == "ElectricCar" || i_VehicleType == "FuelMotorcycle" || i_VehicleType == "ElectricMotorcycle" || i_VehicleType == "FuelTruck";
        }

        private static bool IsLicenseId(string i_LicenseId)
        {
            bool isLicense = false;

            foreach (char c in i_LicenseId)
            {
                if (char.IsDigit(c) ||  c == '-')
                {
                    isLicense = true;
                }
            }

            return isLicense;
        }

        [Obsolete]
        private static bool IsModelName(string v)
        {
            throw new NotImplementedException("Not sure if we need this or not");
        }
    }
}
