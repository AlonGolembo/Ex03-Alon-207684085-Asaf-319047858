using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        public eDrivingLicenceCategory DrivingLicenceCategory { get; set; }
        private int m_EngineCapacity;

        public Motorcycle(string i_LicenseID,
                          string i_ModelName,
                          int i_EngineCapacity,
                          eDrivingLicenceCategory i_DrivingLicenceCategory) : base(i_LicenseID, i_ModelName)
        {
            EngineCapacity = i_EngineCapacity;
            DrivingLicenceCategory = i_DrivingLicenceCategory;
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set
            {
                if (value < 0)
                {
                    throw new ValueRangeException("Engine capacity can't be negative!");
                }
                else
                {
                    m_EngineCapacity = value;
                }
            }
        }
    }
}
