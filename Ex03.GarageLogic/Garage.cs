using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, RegisteredVehicle> VehiclesInGarage;
        public Dictionary<string, RegisteredVehicle> VehiclesInGarage
        {
            get { return VehiclesInGarage; }
        }
        public void InflateWheelsToMax(string i_LicenseID)
        {
            if (VehiclesInGarage.ContainsKey(i_LicenseID))
            {
                foreach (Wheel wheel in VehiclesInGarage[i_LicenseID].Vehicle.Wheels)
                {
                    wheel.CurrentAirPressure = wheel.MaxAirPressure;
                }

            }
            else
            {
                throw new KeyNotFoundException("Vehicle with the given license ID not found in the garage.");
            }
        }


        public void FuelVehicle(string i_LicenseID, eFuelType i_FuelType, float i_AmountToFuel)
        {
            if (VehiclesInGarage.ContainsKey(i_LicenseID))
            {

                if (VehiclesInGarage[i_LicenseID].Vehicle.Engine is FuelEngine)
                {
                    FuelEngine fuelEngine = (FuelEngine)VehiclesInGarage[i_LicenseID].Vehicle.Engine;

                    if (fuelEngine.FuelType != i_FuelType)
                    {
                        throw new ArgumentException("You're asking to fuel above your tank capacity.");
                    }
                    else
                    {
                        if (fuelEngine.CurrentFuelAmount + i_AmountToFuel > fuelEngine.TankCapacity)
                        {
                            throw new ValueOutOfRangeException("You're asking to fuel above your tank capacity.");
                        }
                        else
                        {
                            fuelEngine.CurrentFuelAmount += i_AmountToFuel;
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("The vehicle does not have a fuel engine.");

                }
            }
            else
            {
                throw new KeyNotFoundException("Vehicle with the given license ID not found in the garage.");
            }
        }

        //Need to check if theres a way to use one method for fuel and electric vehicles.

        public void ChargeVehicle(string i_LicenseID, float io_MinutesToCharge)
        {
            if (VehiclesInGarage.ContainsKey(i_LicenseID))
            {
                if (VehiclesInGarage[i_LicenseID].Vehicle.Engine is ElectricEngine)
                {
                    ElectricEngine electricEngine = (ElectricEngine)VehiclesInGarage[i_LicenseID].Vehicle.Engine;

                    if (electricEngine.RemainingBatteryLife + io_MinutesToCharge > electricEngine.MaxBatteryTime)
                    {
                        throw new ValueOutOfRangeException("You're asking to charge above your battery capacity.");
                    }
                    else
                    {
                        electricEngine.RemainingBatteryLife += io_MinutesToCharge;
                    }
                }
                else
                {
                    throw new ArgumentException("The vehicle does not have an electric engine.");
                }

            }
            else
            {
                throw new KeyNotFoundException("Vehicle with the given license ID not found in the garage.");
            }
        } 
    
        
    }
}
