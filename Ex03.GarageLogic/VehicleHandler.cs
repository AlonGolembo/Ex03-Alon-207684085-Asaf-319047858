using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


// Need to think if this calss is even needed.
// Not sure yet, maybe we should let Garage have these methods..
namespace Ex03.GarageLogic
{
    public class VehicleHandler
    {
        private Garage m_Garage;

        public VehicleHandler()
        {
            m_Garage = new Garage();
        }
        public Vehicle GetVehicle(string i_LicenseNumber)
        {
            Vehicle vehicle = null;
            foreach (RegisteredVehicle registeredVehicle in this.m_Garage.VehicleList)
            {
                if (i_LicenseNumber == registeredVehicle.Vehicle.LicenseID)
                {
                    vehicle = registeredVehicle.Vehicle;
                }
            }

            return vehicle;
        }

        public void InsertToGarage(RegisteredVehicle registeredVehicle)
        {
            this.m_Garage.InsertVehicle(registeredVehicle);
        }
    }
}
