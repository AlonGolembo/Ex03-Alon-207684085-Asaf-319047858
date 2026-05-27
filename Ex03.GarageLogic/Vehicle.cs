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
        public Engine Engine { get; set; }
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

        public Vehicle(string i_LicenseNumber, string i_ModelName)
        {
            LicenseNumber = i_LicenseNumber;
            ModelName = i_ModelName;
        }

        protected void InitializeWheelsList(eNumberOfWheels i_NumberOfWheels, float i_MaxAirPressure)
        {
            m_Wheels = new List<Wheel>();
            for (int i = 0; i < (int)i_NumberOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_MaxAirPressure));
            }
        } 
    }    
}
