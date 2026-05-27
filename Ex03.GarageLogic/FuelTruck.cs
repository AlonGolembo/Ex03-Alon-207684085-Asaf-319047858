using System;

namespace Ex03.GarageLogic
{
    public class FuelTruck : Vehicle
    {
        private float? m_CargoVolume;
        public bool? IsRefrigerated { get; set; }
        public float? CargoVolume
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
        public FuelTruck(string i_LicenseID, string i_ModelName, bool i_IsRefrigerated, float i_CargoVolume) : base (i_LicenseID, i_ModelName)
        {
            this.InitializeWheelsList(eNumberOfWheels.Fourteen, 28);
            this.Engine = new FuelEngine(eFuelType.Soler, 125);
            this.IsRefrigerated = i_IsRefrigerated;
            CargoVolume = i_CargoVolume;
        }

        public FuelTruck(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            this.InitializeWheelsList(eNumberOfWheels.Fourteen, 28);
            this.Engine = new FuelEngine(eFuelType.Soler, 125);
            this.IsRefrigerated = null;
            CargoVolume = null;
        }
    }
}