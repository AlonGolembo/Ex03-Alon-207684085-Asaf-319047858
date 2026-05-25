using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        public PowerSource Engine { get; set; }
        private List<Wheel> m_Wheels;

        public string ModelName
        {
            get { return m_ModelName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_ModelName = value;
                }
                else
                {
                    throw new ArgumentNullException("Model name can't be empty!");
                }
            }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_LicenseNumber = value;
                }
                else
                {
                    throw new ArgumentNullException("Liscense number can't be empty!");
                }
            }
        }
    }    
}
