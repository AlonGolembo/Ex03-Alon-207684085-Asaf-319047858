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
                string vehicleType = GetVehicleType();
                string modelName = GetVehicleModel();
                Vehicle currentVehicle = VehicleCreator.CreateVehicle(vehicleType, i_LicenseID, modelName);
                SetVehicleDetails(currentVehicle);
                RegisteredVehicle registeredVehicle = RegisterVehicle(currentVehicle);
                i_VehicleHandler.InsertToGarage(registeredVehicle);
            }
        }

        private static string GetVehicleType()
        {
            Console.WriteLine("Please select a vehicle type: ");
            int typeAmount = 1;
            foreach (string type in VehicleCreator.SupportedTypes)
            {
                Console.WriteLine($"{typeAmount}. {type}");
                typeAmount++;
            }

            if(!int.TryParse(Console.ReadLine(), out int o_TypeNumber))
            {
                throw new FormatException("Can't parse input to a valid vehicle type number!");
            }

            return VehicleCreator.SupportedTypes[o_TypeNumber - 1];
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
            Console.WriteLine("Please insert the motorcycle's license category: ");
            Console.WriteLine("1. A");
            Console.WriteLine("1. A1");
            Console.WriteLine("1. A2");
            Console.WriteLine("1. B");
            string categoryInput = Console.ReadLine();
            if (!eDrivingLicenceCategory.TryParse(categoryInput, true, out eDrivingLicenceCategory o_NewCategory))
            {
                throw new FormatException("Can't parse license category to enum!");
            }
            if(!Enum.IsDefined(typeof(eDrivingLicenceCategory), o_NewCategory))
            {
                throw new ArgumentException("Enum doesn't exist!");
            }
            motorcycleVehicle.LicenseCategory = o_NewCategory;
        }

        private static void GetCarColor(Car carVehicle)
        {
            Console.WriteLine("Please insert the car's color:");
            Console.WriteLine("1. Red");
            Console.WriteLine("1. Yellow");
            Console.WriteLine("1. Black");
            Console.WriteLine("1. Silver");
            string colorInput = Console.ReadLine();
            if (ePaint.TryParse(colorInput, out ePaint color))
            {
                throw new FormatException("Invalid input for car color! Please enter Red, White, Black, or Silver.");  
            }
            if(!Enum.IsDefined(typeof(ePaint), color))
            {
                throw new ArgumentException("Enum doesn't exist!");
            }
            carVehicle.Color = color;
        }

        private static void GetWheelsState(Vehicle i_Vehicle)
        {
            Console.WriteLine("Please insert the current air pressure of the wheels: ");
            float airPressure;
            if (!float.TryParse(Console.ReadLine(), out airPressure))
            {
                throw new FormatException("Can't parse air pressure to a float!");
            }
            if (!(airPressure >= 0 && airPressure <= i_Vehicle.Wheels[0].MaxAirPressure))
            {
                throw new ValueRangeException(0f, i_Vehicle.Wheels[0].MaxAirPressure);
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
