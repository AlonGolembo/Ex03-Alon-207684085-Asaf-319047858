using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        public eDrivingLicenceCategory DrivingLicenceCategory { get; set; }
        private int m_EngineCapacity;

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Engine capacity can't be negative!");
                }
                else
                {
                    m_EngineCapacity = value;
                }
            }
        }

        public Motorcycle(string i_LicenseNumber,
                          string i_ModelName) : base(i_LicenseNumber, i_ModelName) { }
    }
}
