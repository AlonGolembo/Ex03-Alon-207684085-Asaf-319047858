using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private int? m_EngineCapacity;
        public eDrivingLicenceCategory? LicenseCategory { get; set; }

        public int? EngineCapacity
        {
            get { return m_EngineCapacity; }
            set
            {
                if (value < 0)
                {
                    throw new ValueRangeException("Engine capacity can't be negative!");
                }

                m_EngineCapacity = value;
            }
        }

        public Motorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            EngineCapacity = null;
            LicenseCategory = null;
        }
        public Motorcycle(string i_LicenseID,
                          string i_ModelName,
                          int i_EngineCapacity,
                          eDrivingLicenceCategory i_DrivingLicenceCategory) : base(i_LicenseID, i_ModelName)
        {
            EngineCapacity = i_EngineCapacity;
            LicenseCategory = i_DrivingLicenceCategory;
        }

        public override bool InsertSpecificVehicleProperties(string i_Property1, string i_Property2)
        {
            bool canInsert = false;
            if (!eDrivingLicenceCategory.TryParse(i_Property1, out eDrivingLicenceCategory drivingLicenceCategory))
            {
                throw new FormatException("Can't parse driving license category to enum!");
            }
            LicenseCategory = drivingLicenceCategory;

            if (!int.TryParse(i_Property2, out int engineCapacity))
            {
                throw new FormatException("Can't parse engine capacity to int!");
            }
            EngineCapacity = engineCapacity;

            return canInsert;
        }
    }
}
