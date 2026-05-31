using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleHandler
    {
        private readonly Garage m_Garage;
        private readonly Dictionary<string, RegisteredVehicle> m_VehiclesInGarage;

        public Garage Garage
        {
            get { return m_Garage; }
        }   

        public Dictionary<string, RegisteredVehicle> VehiclesInGarage
        {
            get { return m_VehiclesInGarage; }
        }
        public void InsertToGarage(RegisteredVehicle i_registeredVehicle)
        {
            string licenseID = i_registeredVehicle.Vehicle.LicenseID;
            if (!m_VehiclesInGarage.ContainsKey(licenseID))
            {
                m_VehiclesInGarage.Add(licenseID, i_registeredVehicle);
            }
            else
            {
                m_VehiclesInGarage[licenseID].VehicleState = eVehicleState.UnderRepair;
            }
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




    
    
   

