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
        public static void Print(RegisteredVehicle i_Vehicle)
        {
            Console.WriteLine("Vehicle details:");
            Console.WriteLine($"License Number: {i_Vehicle.Vehicle.LicenseID}");
            Console.WriteLine($"Model Name: {i_Vehicle.Vehicle.ModelName}");
            Console.WriteLine($"Owner Name: {i_Vehicle.OwnerName}");
            Console.WriteLine($"Vehicle State: {i_Vehicle.VehicleState}");
            Console.WriteLine($"Wheels Description: ");
            PrintWheels(i_Vehicle.Vehicle.Wheels);
            switch (i_Vehicle.Vehicle.Engine)
            {
                case FuelEngine fuelEngine:
                    Console.WriteLine($"The engine takes {fuelEngine.FuelType} fuel and the tank is {fuelEngine.EnergyPercentage}% full ");
                    break;
                case ElectricEngine electricEngine:
                    Console.WriteLine($"The battery is {electricEngine.EnergyPercentage}% full, you have {electricEngine.RemainingBatteryLife} hours left of battery");
                    break;
            }

            switch (i_Vehicle.Vehicle)
            {
                case Car car:
                    Console.WriteLine($"The car's color is {car.Color} and it has {car.DoorsNumber} doors");
                    break;
                case Motorcycle motorcycle:
                    Console.WriteLine($"The motorcycle license category is {motorcycle.LicenseCategory} and its engine capacity is {motorcycle.EngineCapacity}");
                    break;
                case FuelTruck fuelTruck:
                    Console.WriteLine($"The truck's cargo {((bool)fuelTruck.IsRefrigerated ? "is refrigerated" : "isn't refrigerated")} and its volume is {fuelTruck.CargoVolume}");
                    break;
            }
        }

        public static void GetVehicleFromUserAndPrint(VehicleHandler i_VehicleHandler)
        {
            Console.WriteLine("Insert vehicle's license number: ");
            string licenseNubmer = Console.ReadLine();
            RegisteredVehicle currentVehicle = i_VehicleHandler.GetVehicle(licenseNubmer);
            if(currentVehicle != null)
            {
                Print(currentVehicle);
            }
            else
            {
                Console.WriteLine("Vehicle doesn't exist!");
            }
        }

        public static void LicenseNumber(RegisteredVehicle i_RegisteredVehicle)
        {
            Console.WriteLine($"{i_RegisteredVehicle.Vehicle.LicenseID}");
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
