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
        
        //public VehicleHandler(Garage i_Garage)
        //{
        //    Garage = i_Garage;
        //}

        public List<RegisteredVehicle> DisplayVehicles(eVehicleState i_VehicleState)
        {
            List<RegisteredVehicle> vehicleList = new List<RegisteredVehicle>();
            foreach(RegisteredVehicle vehicle in Garage.Vehicles)
            {
                if(vehicle.m_VehicleState == i_VehicleState)
                {
                    vehicleList.Add(vehicle);
                }
            }

            return vehicleList;
        }
        public RegisteredVehicle GetVehicle(string i_LicenseID)
        {
            if (m_VehiclesInGarage.ContainsKey(i_LicenseID))
            {
                return m_VehiclesInGarage[i_LicenseID];
            }
            else
            {
                return null;
            }
        }
        public List<string> GetAllLicenseNumbers()
        {
            List<string> licenseNumberList = new List<string>();

            foreach (string licenseNumber in m_VehiclesInGarage.Keys)
            {
                licenseNumberList.Add(licenseNumber);
            }
            return licenseNumberList;
        }
        public void ChangeVehicleState(string i_LicenseID, eVehicleState i_NewState)
        {
            if (m_VehiclesInGarage.ContainsKey(i_LicenseID))
            {
                m_VehiclesInGarage[i_LicenseID].VehicleState = i_NewState;
            }
            else
            {
                throw new KeyNotFoundException("Vehicle with the given license ID not found in the garage.");
            }
        }

    }
}




    
    
   

