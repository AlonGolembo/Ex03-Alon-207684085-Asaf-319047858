using System;

namespace Ex03.GarageLogic
{
    public class FuelTruck : Vehicle
    {
        private float m_CargoVolume;
        public bool IsRefrigerated { get; set; }
        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Volume can't be negative!");
                }

                m_CargoVolume = value;
            }
        }
        public FuelTruck(string i_LicenseID, string i_ModelName) : base (i_LicenseID, i_ModelName)
        {
            
        }
    }
}