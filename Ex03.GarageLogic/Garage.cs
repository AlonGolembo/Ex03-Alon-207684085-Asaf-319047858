using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Ex03.GarageLogic
{
    internal class Garage
    {
        private List<RegisteredVehicle> m_VehiclesList;

        public IEnumerable<RegisteredVehicle> VehicleList
        {
            get
            {
                return m_VehiclesList;
            }
        }

        public Garage()
        {
            m_VehiclesList = new List<RegisteredVehicle>();
        }
        public Garage(List<RegisteredVehicle> vehicles)
        {
            foreach (RegisteredVehicle vehicle in vehicles)
            {
                this.InsertVehicle(vehicle);
            }
        }

        internal void InsertVehicle(RegisteredVehicle registeredVehicle)
        {
            m_VehiclesList.Add(registeredVehicle);
        }
    }
}