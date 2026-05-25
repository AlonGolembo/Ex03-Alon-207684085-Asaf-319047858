using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyPercent;
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

        public float EnergyPercent
        {
            get { return m_EnergyPercent; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Energy percent can't be negative!");
                }
            }
        }

        public Vehicle(string i_ModelName, string i_LicenseNumber)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyPercent = 100;
            m_Wheels = new List<Wheel>();
        }
    }    
}
