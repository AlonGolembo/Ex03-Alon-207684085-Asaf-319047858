using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class InsertVehicleToGarage
    {
        private static bool IsLicenseNumberInGarage(string i_LicenseNumber)
        {
            return VehicleHandler.GetVehicle(i_LicenseNumber) != null;
        }

        public static void Insert(string i_LicenseNumber)
        {
            if (IsLicenseNumberInGarage(i_LicenseNumber))
            {
                Console.WriteLine($"Vehicle {i_LicenseNumber} is already in garage, starting to repair it...");
                VehicleHandler.GetVehicle(i_LicenseNumber).VehicleState = eVehicleState.UnderRepair;
                //foreach (RegisteredVehicle registeredVehicle in Garage.VehiclesList)
                //{
                //    if (i_LicenseNumber == registeredVehicle.Vehicle.LicenseID)
                //    {
                //        registeredVehicle.VehicleState = eVehicleState.UnderRepair;
                //    }
                //}
            }
            else
            {
                Console.WriteLine("Please insert your vehicle type: ");
                string vehicleType = Console.ReadLine();

                if (!VehicleCreator.SupportedTypes.Contains(vehicleType))
                {
                    throw new FormatException("Vehicle type doens't exist!");
                }

                string modelName = GetVehicleModel();
                Vehicle currentVehicle = VehicleCreator.CreateVehicle(vehicleType, i_LicenseNumber, modelName);
                SetVehicleDetails(currentVehicle);
                RegisteredVehicle registeredVehicle = RegisterVehicle(currentVehicle);
                VehicleHandler.InsertToGarage(registeredVehicle);
            }
        }

        private static string GetVehicleModel()
        {
            Console.WriteLine("Please insert the vehicle's model name: ");
            return Console.ReadLine();
        }

        private static void SetVehicleDetails(Vehicle i_Vehicle)
        {
            GetEnergyPercentage(i_Vehicle);
            GetWheelsState(i_Vehicle);
            switch (i_Vehicle)
            {
                case Car carVehicle:
                    GetCarColor(carVehicle);
                    break;
                case Motorcycle motorcycleVehicle:
                    GetDrivingLicenseCategory(motorcycleVehicle);
                    break;
                case FuelTruck truckVehicle:
                    GetIsRefrigirated(truckVehicle);
                    break;
            }
        }

        private static void GetIsRefrigirated(FuelTruck truckVehicle)
        {
            throw new NotImplementedException();
        }

        private static void GetDrivingLicenseCategory(Motorcycle motorcycleVehicle)
        {
            throw new NotImplementedException();
        }

        private static void GetCarColor(Car carVehicle)
        {
            throw new NotImplementedException();
        }

        private static void GetWheelsState(Vehicle i_Vehicle)
        {
            throw new NotImplementedException();
        }

        private static RegisteredVehicle RegisterVehicle(Vehicle i_Vehicle)
        {
            Console.WriteLine("Please insert car owners name: ");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Please insert car owners phone number: ");
            string ownerPhoneNumber = Console.ReadLine();

            return new RegisteredVehicle(i_Vehicle, ownerName, ownerPhoneNumber);
        }

        private static void GetEnergyPercentage(Vehicle i_Vehicle)
        {
            switch (i_Vehicle.Engine)
            {
                case FuelEngine fuelEngine:
                    Console.WriteLine("Insert vehicle's fuel percentage: ");
                    float fuelPercentage;
                    if (!float.TryParse(Console.ReadLine(), out fuelPercentage))
                    {
                        throw new FormatException("Can't parse fuel percentage to a float!");
                    }

                    i_Vehicle.Engine.EnergyPercentage = fuelPercentage;
                    
                    break;

                case ElectricEngine electricEngine:
                    Console.WriteLine("Insert vehicle's battery percentage: ");
                    float batteryPercentage;
                    if (!float.TryParse(Console.ReadLine(), out batteryPercentage))
                    {
                        throw new FormatException("Can't parse battery percentage to a float!");
                    }

                    i_Vehicle.Engine.EnergyPercentage = batteryPercentage;

                    break;
            }
        }
    }
}
