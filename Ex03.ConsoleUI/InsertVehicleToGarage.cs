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
        public static void Insert(VehicleHandler i_VehicleHandler, string i_LicenseID)
        {
            RegisteredVehicle existingVehicle = i_VehicleHandler.GetVehicle(i_LicenseID);
            if (existingVehicle != null)
            {
                Console.WriteLine($"Vehicle {i_LicenseID} is already in garage, starting to repair it...");
                existingVehicle.VehicleState = eVehicleState.UnderRepair;
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
                Vehicle currentVehicle = VehicleCreator.CreateVehicle(vehicleType, i_LicenseID, modelName);
                SetVehicleDetails(currentVehicle);
                RegisteredVehicle registeredVehicle = RegisterVehicle(currentVehicle);
                i_VehicleHandler.InsertToGarage(registeredVehicle);
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
            Console.WriteLine("Is the truck refrigerated? (Y/N)");
            string isRefrigeratedInput = Console.ReadLine();
            if (isRefrigeratedInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                truckVehicle.IsRefrigerated = true;
            }
            else if (isRefrigeratedInput.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                truckVehicle.IsRefrigerated = false;
            }
            else
            {
                throw new FormatException("Invalid input for refrigerated status! Please enter Y or N.");
            }
        }

        private static void GetDrivingLicenseCategory(Motorcycle motorcycleVehicle)
        {
           Console.WriteLine("Please insert the motorcycle's driving license category (A, A1, A2, B): ");
            string categoryInput = Console.ReadLine();
            if (Enum.TryParse(categoryInput, true, out eDrivingLicenceCategory category))
            {
                motorcycleVehicle.DrivingLicenceCategory = category;
            }
            else
            {
                throw new FormatException("Invalid input for driving license category! Please enter A, A1, A2, or B.");
            }
        }

        private static void GetCarColor(Car carVehicle)
        {
        Console.WriteLine("Please insert the car's color (Red, White, Black, Silver): ");
            string colorInput = Console.ReadLine();
            if (Enum.TryParse(colorInput, true, out ePaint color))
            {
                carVehicle.Color = color;
            }
            else
            {
                throw new FormatException("Invalid input for car color! Please enter Red, White, Black, or Silver.");
            }
        }

        private static void GetWheelsState(Vehicle i_Vehicle)
        {
            Console.WriteLine("Please insert the current air pressure of the wheels: ");
            float airPressure;
            if (!float.TryParse(Console.ReadLine(), out airPressure))
            {
                throw new FormatException("Can't parse air pressure to a float!");
            }
            if (airPressure < 0)
            {
                throw new ValueRangeException("Air pressure can't be negative!");
            }
            if (airPressure > i_Vehicle.Wheels[0].MaxAirPressure)
            {
                throw new ValueRangeException($"Air pressure can't be higher than {i_Vehicle.Wheels[0].MaxAirPressure}!");
            }
           
            Console.WriteLine("Please enter manufacturer's name:");
            string manufacturerName = Console.ReadLine();
            
            if(string.IsNullOrWhiteSpace(manufacturerName))
            {
                throw new ArgumentNullException("Manufacturer name can't be empty or just spaces!");
            }
            i_Vehicle.SetWheels(manufacturerName, airPressure);
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
