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
                    throw new ValueRangeException("Volume can't be negative!");
                }

                m_CargoVolume = value;
            }
        }
        public FuelTruck(string i_LicenseID, string i_ModelName, bool i_IsRefrigerated, float i_CargoVolume) : base (i_LicenseID, i_ModelName)
        {
            InitializeWheelsList(eNumberOfWheels.Fourteen, 28);
            Engine = new FuelEngine(eFuelType.Soler, 125);
            IsRefrigerated = i_IsRefrigerated;
            CargoVolume = i_CargoVolume;
        }

        public FuelTruck(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            InitializeWheelsList(eNumberOfWheels.Fourteen, 28);
            Engine = new FuelEngine(eFuelType.Soler, 125);
            IsRefrigerated = null;
            CargoVolume = null;
        }

        public override bool InsertSpecificVehicleProperties(string i_IsRefrigerated, string i_CargoVolume)
        {
            bool canInsert = false;
            if (!bool.TryParse(i_IsRefrigerated, out bool isRefrigerated))
            {
                throw new FormatException("Can't parse is refrigerated to boolean value!");
            }
            IsRefrigerated = isRefrigerated;

            if (!float.TryParse(i_CargoVolume, out float cargoVolume))
            {
                throw new FormatException("Can't parse engine capacity to int!");
            }
            CargoVolume = cargoVolume;

            return canInsert;
        }
    }
}