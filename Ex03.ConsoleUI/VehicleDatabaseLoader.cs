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
        public static void Load(VehicleHandler i_VehicleHandler, string i_fileName)
        {
            int linesRead = 0;
            string[] dbLines = File.ReadAllLines(i_fileName);
            foreach (string dbLine in dbLines)
            {
                try
                {
                    RegisteredVehicle registeredVehicle = ParseLine(dbLine);
                    i_VehicleHandler.InsertToGarage(registeredVehicle);
                    Console.WriteLine($"Vehicle {registeredVehicle.Vehicle.LicenseID} was loaded to the garage system.");
                    linesRead++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Moving to the next line...");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"{linesRead} vehicles were loaded to the garage system");
            Console.WriteLine();
        }
        private static RegisteredVehicle ParseLine(string i_Line)
        {
            string[] lineDetails = i_Line.Split(',');
            if (!IsVehicleType(lineDetails[0]) || !IsLicenseId(lineDetails[1]))
            {
                throw new FormatException($"Line '{i_Line}' isn't a valid vehicle!");
            }

            Vehicle currentVehicle = VehicleCreator.CreateVehicle(lineDetails[0], lineDetails[1], lineDetails[2]);


            // Need to add exception here
            if (float.TryParse(lineDetails[5], out float currentAirPressure))
            {
                currentVehicle.SetWheels(lineDetails[4], currentAirPressure);
            }

            // Need to add exception here
            if (float.TryParse(lineDetails[3], out float energyPercentage))
            {
                currentVehicle.Engine.EnergyPercentage = energyPercentage;
            }

            RegisteredVehicle registeredVehicle = new RegisteredVehicle(currentVehicle, lineDetails[6], lineDetails[7]);

            return registeredVehicle;
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
