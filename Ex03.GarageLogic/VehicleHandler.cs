using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleHandler
    {
        public static Vehicle GetVehicle(string i_LicenseNumber)
        {
            Vehicle vehicle = null;
            foreach (RegisteredVehicle registeredVehicle in Garage.VehiclesList)
            {
                if (i_LicenseNumber == registeredVehicle.Vehicle.LicenseID)
                {
                    vehicle = registeredVehicle.Vehicle;
                }
            }

            return vehicle;
        }

        public static void InsertToGarage(Vehicle currentVehicle)
        {
            throw new NotImplementedException();
        }
    }
}
