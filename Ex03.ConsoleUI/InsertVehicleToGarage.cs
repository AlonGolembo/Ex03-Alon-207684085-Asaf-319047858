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
                GetVehicleDetails(currentVehicle);
                RegisteredVehicle registeredVehicle = RegisterVehicle(currentVehicle);
                i_VehicleHandler.InsertToGarage(registeredVehicle);

                // Print successful insertion
                Console.WriteLine($"Vehicle {registeredVehicle.Vehicle.LicenseID} was successfuly inserted to the garage!");
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

        private static void GetVehicleDetails(Vehicle i_Vehicle)
        {
            GetEnergyPercentage(i_Vehicle);
            GetWheelsState(i_Vehicle);
            switch (i_Vehicle)
            {
                case Car carVehicle:
                    GetCarDetails(carVehicle);
                    break;
                case Motorcycle motorcycleVehicle:
                    GetMotorcycleDetails(motorcycleVehicle);
                    break;
                case FuelTruck truckVehicle:
                    GetTruckDetails(truckVehicle);
                    break;
            }
        }

        private static void GetTruckDetails(FuelTruck truckVehicle)
        {
            string isRefrigeratedInput;
            Console.WriteLine("Is the truck refrigerated?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            if(!int.TryParse(Console.ReadLine(), out int userAnswer))
            {
                throw new FormatException("Can't parse answer to number!");
            }
            if(!(userAnswer == 1 || userAnswer == 2))
            {
                throw new ArgumentException("Invalid choice!");
            }
            if(userAnswer == 1)
            {
                isRefrigeratedInput = "true";
            }
            else
            {
                isRefrigeratedInput = "false";
            }

            Console.WriteLine("Insert the truck cargo volume: ");
            string cargoVolumeInput = Console.ReadLine();

            truckVehicle.InsertSpecificVehicleProperties(isRefrigeratedInput, cargoVolumeInput);
        }

        private static void GetMotorcycleDetails(Motorcycle motorcycleVehicle)
        {
            Console.WriteLine("Please insert the motorcycle's license category: ");
            Console.WriteLine("1. A");
            Console.WriteLine("2. A1");
            Console.WriteLine("3. A2");
            Console.WriteLine("4. B");
            string categoryInput = Console.ReadLine();

            Console.WriteLine("Please insert the motorcycle's engine capacity: ");
            string engineCapacityInput = Console.ReadLine();

            motorcycleVehicle.InsertSpecificVehicleProperties(categoryInput, engineCapacityInput);
        }

        private static void GetCarDetails(Car carVehicle)
        {
            Console.WriteLine("Please insert the car's color:");
            Console.WriteLine("1. Red");
            Console.WriteLine("2. Yellow");
            Console.WriteLine("3. Black");
            Console.WriteLine("4. Silver");
            string colorInput = Console.ReadLine();

            Console.WriteLine("Please insert the number of doors:");
            Console.WriteLine("1. Two");
            Console.WriteLine("2. Three");
            Console.WriteLine("3. Four");
            Console.WriteLine("4. Five");
            string doorsNumber = Console.ReadLine();

            carVehicle.InsertSpecificVehicleProperties(colorInput, doorsNumber);
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
