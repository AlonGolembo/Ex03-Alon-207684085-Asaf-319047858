using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleHandler
    {

        private readonly RegisteredVehicle m_RegisteredVehicle;
        private eVehicleState m_VehicleState;



        public VehicleHandler(RegisteredVehicle i_RegisteredVehicle)
        {
            m_RegisteredVehicle = i_RegisteredVehicle;
            m_VehicleState = eVehicleState.UnderRepair; 
        }


        public RegisteredVehicle RegisteredVehicle
        {
            get { return m_RegisteredVehicle; }
        }
        public eVehicleState VehicleState
        {
            get { return m_VehicleState; }
            set { m_VehicleState = value; }
        }



        public void InflateWheelsToMax()
        {
            List<Wheel> vehicleWheels = m_RegisteredVehicle.Vehicle.Wheels;
            foreach (Wheel wheel in vehicleWheels)
            {
                float airToAdd = wheel.MaxAirPressure - wheel.CurrentAirPressure;

                if (airToAdd > 0)
                {
                    wheel.Inflate(airToAdd); 
                }
            }
        }


        public void FuelVehicle(eFuelType i_FuelType, float i_AmountToFuel)
        {
            if (m_RegisteredVehicle.Vehicle.Engine is FuelEngine fuelEngine)
            {

                fuelEngine.Refuel(i_AmountToFuel, i_FuelType);
            }
            else
            {

                throw new ArgumentException("Error: Cannot fuel an electric vehicle!");
            }
        }

       
        public void ChargeVehicle(float i_MinutesToCharge)
        {
            if (m_RegisteredVehicle.Vehicle.Engine is ElectricEngine electricEngine)
            {
                float hoursToCharge = i_MinutesToCharge / 60f;
                electricEngine.ChargeBattery(hoursToCharge);
            }
            else
            {

                throw new ArgumentException("Error: Cannot charge a fuel-based vehicle!");
            }
        }

        
        public override string ToString()
        {
            return string.Format(
                "{0}\n{1}\nStatue in Garage: {2}",
                m_RegisteredVehicle.Vehicle.ToString(),
                m_RegisteredVehicle.ToString(),
                m_VehicleState.ToString()
            );
        }
    }
}




    
    
   

