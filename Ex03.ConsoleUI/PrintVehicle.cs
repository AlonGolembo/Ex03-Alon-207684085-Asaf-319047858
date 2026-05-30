using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using System.Runtime.CompilerServices;

namespace Ex03.ConsoleUI
{
    public class PrintVehicle
    {
        public static void Print(string i_LicenseNumber)
        {
            RegisteredVehicle registeredVehicle = i_VehicleHandler.GetVehicle(i_LicenseNumber);
            if (registeredVehicle == null)
            {
                throw new ArgumentNullException("License number doesn't exist!");
            }

            Console.WriteLine("Vehicle details:");
            Console.WriteLine($"License Number: {registeredVehicle.Vehicle.LicenseID}");
            Console.WriteLine($"Model Name: {registeredVehicle.Vehicle.ModelName}");
            Console.WriteLine($"Owner Name: {registeredVehicle.OwnerName}");
            Console.WriteLine($"Vehicle State: {registeredVehicle.VehicleState}");
            Console.WriteLine($"Wheels Description: ");
            PrintWheels(registeredVehicle.Vehicle.Wheels);
            switch (registeredVehicle.Vehicle.Engine)
            {
                case FuelEngine fuelEngine:
                    Console.WriteLine($"The engine takes {fuelEngine.FuelType} fuel and the tank is {fuelEngine.EnergyPercentage}% full ");
                    break;
                case ElectricEngine electricEngine:
                    Console.WriteLine($"The battery is {electricEngine.EnergyPercentage}% full, you have {electricEngine.RemainingBatteryLife} hours left of battery");
                    break;
            }

            switch (registeredVehicle.Vehicle)
            {
                case FuelTruck fuelTruck:
                    Console.WriteLine($"Add FuelTruck details here...");
                    break;
                case FuelCar fuelCar:
                    Console.WriteLine($"Add FuelCar details here...");
                    break;
                case ElectricCar electricCar:
                    Console.WriteLine($"Add ElectricCar details here...");
                    break;
                case FuelMotorcycle fuelMotorcycle:
                    Console.WriteLine($"Add FuelMotorcycle details here...");
                    break;
                case ElectricMotorcycle fuelMotorcycle:
                    Console.WriteLine($"Add ElectricMotorcycle details here...");
                    break;
            }
        }

        private static void PrintWheels(List<Wheel> i_wheels)
        {
            Console.WriteLine($"This vehicle has {i_wheels.Count} wheels");
            Console.WriteLine($"Wheels status: ");
            int i_WheelCount = 1;
            foreach (Wheel w in i_wheels)
            {
                Console.WriteLine($"Wheel number {i_WheelCount}: ");
                Console.WriteLine($"Manafatured: {w.ManufacturerName}");
                Console.WriteLine($"Air pressure: {w.CurrentAirPressure}");
                Console.WriteLine("");
                i_WheelCount++;
            }
        }
    }
}
