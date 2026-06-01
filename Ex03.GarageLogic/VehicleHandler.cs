using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleHandler
    {
        public Garage Garage { get; set; }

        public VehicleHandler()
        {
            Garage = new Garage();
        }

        public List<RegisteredVehicle> DisplayVehicles(eVehicleState i_VehicleState)
        {
            List<RegisteredVehicle> vehicleList = new List<RegisteredVehicle>();
            foreach (RegisteredVehicle vehicle in Garage.VehiclesInGarage.Values)
            {
                if(vehicle.VehicleState == i_VehicleState)
                {
                    vehicleList.Add(vehicle);
                }
            }

            return vehicleList;
        }
        public RegisteredVehicle GetVehicle(string i_LicenseID)
        {
            RegisteredVehicle vehicle = null;
            if (Garage.VehiclesInGarage.ContainsKey(i_LicenseID))
            {
                vehicle = Garage.VehiclesInGarage[i_LicenseID];
            }

            return vehicle;
        }

        public void ChangeVehicleState(string i_LicenseID, eVehicleState i_NewState)
        {
            if (GetVehicle(i_LicenseID) == null)
            {
                throw new VehicleNotFoundException(i_LicenseID);
            }

            Garage.VehiclesInGarage[i_LicenseID].VehicleState = i_NewState;
        }

        public void FillAir(string i_LicenseID)
        {
            if (GetVehicle(i_LicenseID) == null)
            {
                throw new VehicleNotFoundException(i_LicenseID);
            }
            Garage.InflateWheelsToMax(i_LicenseID);
        }

        public void ChargeVehicle(string i_LicenseID, float minutesToCharge)
        {
            if(GetVehicle(i_LicenseID) == null)
            {
                throw new VehicleNotFoundException(i_LicenseID);
            }
            Garage.ChargeVehicle(i_LicenseID, minutesToCharge);
        }

        public void FuelVehicle(string i_LicenseID, eFuelType i_FuelType, float i_FuelLiters)
        {
            RegisteredVehicle vehicleToFuel = GetVehicle(i_LicenseID);
            if (vehicleToFuel == null)
            {
                throw new VehicleNotFoundException(i_LicenseID);
            }

            if (!(vehicleToFuel.Vehicle.Engine is FuelEngine fuelEngine))
            {
                throw new ArgumentException("The vehicle is not a fuel vehicle!");
            }

            Garage.FuelVehicle(i_LicenseID, i_FuelType, i_FuelLiters);
        }

        public void InsertToGarage(RegisteredVehicle registeredVehicle)
        {
            // Currently there is no limitation to insert a new vehicle into garage
            // If in the future there would be any limitation (for example space limit)
            // Add verification here

            if(GetVehicle(registeredVehicle.Vehicle.LicenseID) != null)
            {
                throw new ArgumentException($"Vehicle {registeredVehicle.Vehicle.LicenseID} already exists in garage!");
            }

            Garage.AddVehicle(registeredVehicle);
        }
    }
}