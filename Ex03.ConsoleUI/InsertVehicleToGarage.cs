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
                // Get vehicle type and model from user
                string vehicleType = GetVehicleType();
                string modelName = GetVehicleModel();

                // Create the vehicle object
                Vehicle currentVehicle = VehicleCreator.CreateVehicle(vehicleType, i_LicenseID, modelName);

                // Get and insert vehicle specific and owner's details
                GetVehicleDetails(currentVehicle);
                RegisteredVehicle registeredVehicle = RegisterVehicle(currentVehicle);
                i_VehicleHandler.InsertToGarage(registeredVehicle);

                // Print successful insertion
                Console.WriteLine($"Vehicle {registeredVehicle.Vehicle.LicenseID} was successfuly inserted to the garage!");
            }
        }

        private static string GetVehicleType()
        {
            int vehicleType = 0;
            bool tryAgain = true;
            while(tryAgain)
            {
                Console.WriteLine("Please select a vehicle type: ");
                int typeAmount = 1;
                foreach (string type in VehicleCreator.SupportedTypes)
                {
                    Console.WriteLine($"{typeAmount}. {type}");
                    typeAmount++;
                }

                try
                {
                    vehicleType = ReadVehicleType();
                    tryAgain = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again!");
                }
                
            }

            return VehicleCreator.SupportedTypes[vehicleType - 1];
        }

        private static int ReadVehicleType()
        {
            if (!int.TryParse(Console.ReadLine(), out int o_TypeNumber))
            {
                throw new FormatException("Can't parse input to a valid vehicle type number!");
            }
            if (!(o_TypeNumber > 0 && o_TypeNumber < VehicleCreator.SupportedTypes.Count))
            {
                throw new ValueRangeException(0f, (float)VehicleCreator.SupportedTypes.Count);
            }

            return o_TypeNumber;
        }

        private static string GetVehicleModel()
        {
            string userInput = null;
            bool tryAgain = true;
            while(tryAgain)
            {
                Console.WriteLine("Please insert the vehicle's model name: ");
                try
                {
                    userInput = ReadVehicleModel();
                    tryAgain = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again!");
                }
            }
            
            return userInput;
        }

        private static string ReadVehicleModel()
        {
            string vehicleModel = Console.ReadLine();
            if (string.IsNullOrEmpty(vehicleModel))
            {
                throw new ArgumentException("Model name can't be empty!");
            }

            return vehicleModel;
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
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    string isRefrigerated = ReadIsRefrigerated();
                    string cargoVolume = ReadCargoVolume();
                    truckVehicle.InsertSpecificVehicleProperties(isRefrigerated, cargoVolume);
                    tryAgain = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Pleae try again!");
                }
            }
        }

        private static string ReadCargoVolume()
        {
            Console.WriteLine("Insert the truck cargo volume: ");
            string cargoVolumeInput = Console.ReadLine();
            return cargoVolumeInput;
        }

        private static string ReadIsRefrigerated()
        {
            string isRefrigeratedInput;
            Console.WriteLine("Is the truck refrigerated?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            if (!int.TryParse(Console.ReadLine(), out int userAnswer))
            {
                throw new FormatException("Can't parse answer to number!");
            }
            if (!(userAnswer == 1 || userAnswer == 2))
            {
                throw new ArgumentException("Invalid choice!");
            }
            if (userAnswer == 1)
            {
                isRefrigeratedInput = "true";
            }
            else
            {
                isRefrigeratedInput = "false";
            }

            return isRefrigeratedInput;
        }

        private static void GetMotorcycleDetails(Motorcycle motorcycleVehicle)
        {
            bool tryAgain = true;
            while(tryAgain)
            {
                try 
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
                    tryAgain = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again!");
                }
            }
        }

        private static void GetCarDetails(Car carVehicle)
        {
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    Console.WriteLine("Please insert the car's color:");
                    Console.WriteLine("1. Red");
                    Console.WriteLine("2. Yellow");
                    Console.WriteLine("3. Black");
                    Console.WriteLine("4. Silver");
                    string colorInput = Console.ReadLine();

                    Console.WriteLine("Please insert the number of doors (2-5):");
                    string doorsNumber = Console.ReadLine();
                    carVehicle.InsertSpecificVehicleProperties(colorInput, doorsNumber);
                    tryAgain = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again!");
                }
            }
        }

        private static void GetWheelsState(Vehicle i_Vehicle)
        {
            string manufacturerName = null;
            float airPressure = 0;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    airPressure = ReadAirPressure(i_Vehicle);
                    tryAgain = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again!");
                }
            }

            while (tryAgain)
            {
                try
                {
                    manufacturerName = ReadManafacturerName(i_Vehicle);
                    tryAgain = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again!");
                }
            }

            i_Vehicle.SetWheels(manufacturerName, airPressure);
        }

        private static string ReadManafacturerName(Vehicle i_Vehicle)
        {
            Console.WriteLine("Please enter the wheel's manufacturer's name:");
            string manufacturerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(manufacturerName))
            {
                throw new ArgumentNullException("Manufacturer name can't be empty or just spaces!");
            }

            return manufacturerName;
        }

        private static float ReadAirPressure(Vehicle i_Vehicle)
        {
            Console.WriteLine("Please insert the current air pressure of the wheels: ");
            if (!float.TryParse(Console.ReadLine(), out float airPressure))
            {
                throw new FormatException("Can't parse air pressure to a float!");
            }
            if (!(airPressure >= 0 && airPressure <= i_Vehicle.Wheels[0].MaxAirPressure))
            {
                throw new ValueRangeException(0f, i_Vehicle.Wheels[0].MaxAirPressure);
            }

            return airPressure;
        }

        private static RegisteredVehicle RegisterVehicle(Vehicle i_Vehicle)
        {
            RegisteredVehicle registeredVehicle = null;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    Console.WriteLine("Please insert car owners name: ");
                    string ownerName = Console.ReadLine();
                    Console.WriteLine("Please insert car owners phone number: ");
                    string ownerPhoneNumber = Console.ReadLine();
                    registeredVehicle = new RegisteredVehicle(i_Vehicle, ownerName, ownerPhoneNumber);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again!");
                }
            }

            return registeredVehicle;
        }

        private static void GetEnergyPercentage(Vehicle i_Vehicle)
        {
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    ReadEnergyPercentage(i_Vehicle);
                    tryAgain = false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again!");
                }
            }
            
            
        }

        private static void ReadEnergyPercentage(Vehicle i_Vehicle)
        {
            switch (i_Vehicle.Engine)
            {
                case FuelEngine fuelEngine:
                    Console.WriteLine("Insert vehicle's fuel percentage: ");
                    if (!float.TryParse(Console.ReadLine(), out float fuelPercentage))
                    {
                        throw new FormatException("Can't parse fuel percentage to a float!");
                    }

                    i_Vehicle.Engine.EnergyPercentage = fuelPercentage;

                    break;

                case ElectricEngine electricEngine:
                    Console.WriteLine("Insert vehicle's battery percentage: ");
                    if (!float.TryParse(Console.ReadLine(), out float batteryPercentage))
                    {
                        throw new FormatException("Can't parse battery percentage to a float!");
                    }

                    i_Vehicle.Engine.EnergyPercentage = batteryPercentage;

                    break;
            }
        }

        internal static void GetVehicleFromUser(VehicleHandler i_VehicleHandler)
        {
            Console.WriteLine("Please Enter a vehicle's license number: ");
            string userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                throw new ArgumentException("License number can't be empty!");
            }
            InsertVehicleToGarage.Insert(i_VehicleHandler, userInput);
        }
    }
}
