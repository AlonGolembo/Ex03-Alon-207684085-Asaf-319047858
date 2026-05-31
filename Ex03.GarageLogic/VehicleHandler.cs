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


        // private readonly RegisteredVehicle m_RegisteredVehicle;
        //private eVehicleState m_VehicleState;

        //Add GetVehicle method to return
        //the registered vehicle in case
        //we need to check if it already exists in the garage or not


      
         

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

        // public VehicleHandler(RegisteredVehicle i_RegisteredVehicle)
        //{
        //  m_RegisteredVehicle = i_RegisteredVehicle;
        //m_VehicleState = eVehicleState.UnderRepair; 
        // }


        //public RegisteredVehicle RegisteredVehicle
        //{
        //    get { return m_RegisteredVehicle; }
        //}
        //public eVehicleState VehicleState
        //{
        //    get { return m_VehicleState; }
        //    set { m_VehicleState = value; }
        //}



        //public void InflateWheelsToMax() -->> Garage class
        //{
        //    List<Wheel> vehicleWheels = m_RegisteredVehicle.Vehicle.Wheels;
        //    foreach (Wheel wheel in vehicleWheels)
        //    {
        //        float airToAdd = wheel.MaxAirPressure - wheel.CurrentAirPressure;

        //        if (airToAdd > 0)
        //        {
        //            wheel.Inflate(airToAdd); 
        //        }
        //    }
        //}


        //public void FuelVehicle(eFuelType i_FuelType, float i_AmountToFuel) -->> Garage class
        //{
        //    if (m_RegisteredVehicle.Vehicle.Engine is FuelEngine fuelEngine)
        //    {

        //        fuelEngine.Refuel(i_AmountToFuel, i_FuelType);
        //    }
        //    else
        //    {

        //        throw new ArgumentException("Error: Cannot fuel an electric vehicle!");
        //    }
        //}


        //public void ChargeVehicle(float i_MinutesToCharge) -->> Garrage class
        //{
        //    if (m_RegisteredVehicle.Vehicle.Engine is ElectricEngine electricEngine)
        //    {
        //        float hoursToCharge = i_MinutesToCharge / 60f;
        //        electricEngine.ChargeBattery(hoursToCharge);
        //    }
        //    else
        //    {

        //        throw new ArgumentException("Error: Cannot charge a fuel-based vehicle!");
        //    }
        //}


        //public override string ToString() -->> Refraze the to string to methods that prints after filtering the vehicles in the garage by their state and type, and add the vehicle state to the printout
        //{
        //    return string.Format(
        //        "{0}\nStatue in Garage: {1}",
        //        m_RegisteredVehicle.ToString(),
        //        m_VehicleState.ToString()
        //    );
        //}
    }
}




    
    
   

