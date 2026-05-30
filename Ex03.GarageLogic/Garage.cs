using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, VehicleHandler> m_VehiclesInGarage;

        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<string, VehicleHandler>();
        }
        // Need to check if to keep the insert method void or bool , any maybe throw an exception 
        public void InsertVehicle(RegisteredVehicle i_RegisteredVehicle)
        {
            string licenseID = i_RegisteredVehicle.Vehicle.LicenseID;
            if (!m_VehiclesInGarage.ContainsKey(licenseID))
            {
                VehicleHandler newHandler = new VehicleHandler(i_RegisteredVehicle);
                m_VehiclesInGarage.Add(licenseID, newHandler);

            }
            else
            {
                m_VehiclesInGarage[licenseID].VehicleState = eVehicleState.UnderRepair;
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
        public void InflateWheelsToMax(string i_LicenseID)
        {
            if (m_VehiclesInGarage.ContainsKey(i_LicenseID))
            {
                m_VehiclesInGarage[i_LicenseID].InflateWheelsToMax();
            }
            else
            {
                throw new KeyNotFoundException("Vehicle with the given license ID not found in the garage.");
            }
        }
        public void FuelVehicle(string i_LicenseID, eFuelType i_FuelType, float i_AmountToFuel)
        {
            if (m_VehiclesInGarage.ContainsKey(i_LicenseID))
            {
                m_VehiclesInGarage[i_LicenseID].FuelVehicle(i_FuelType, i_AmountToFuel);
            }
            else
            {
                throw new KeyNotFoundException("Vehicle with the given license ID not found in the garage.");
            }
        }
        public void ChargeVehicle(string i_LicenseID, float i_MinutesToCharge)
        {
            if (m_VehiclesInGarage.ContainsKey(i_LicenseID))
            {
                m_VehiclesInGarage[i_LicenseID].ChargeVehicle(i_MinutesToCharge);
            }
            else
            {
                throw new KeyNotFoundException("Vehicle with the given license ID not found in the garage.");
            }
        }  
        
        public string GetVehicleDetails(string i_LicenseID)
        {
            if (m_VehiclesInGarage.ContainsKey(i_LicenseID))
            {
                return m_VehiclesInGarage[i_LicenseID].RegisteredVehicle.ToString();
            }
            else
            {
                throw new KeyNotFoundException("Vehicle with the given license ID not found in the garage.");
            }
        }
        private VehicleHandler GetVehicleHandler(string i_LicenseID) 
        {
            if (!m_VehiclesInGarage.ContainsKey(i_LicenseID))
            {
                throw new ArgumentException(string.Format("Error: Vehicle with license number '{0}' is not registered in the garage.", i_LicenseID));
            }

            return m_VehiclesInGarage[i_LicenseID];
        }
    }
}
