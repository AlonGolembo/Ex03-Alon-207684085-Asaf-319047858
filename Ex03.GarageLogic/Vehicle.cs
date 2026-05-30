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
        private string m_LicenseID;
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

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }

        public string LicenseID
        {
            get { return m_LicenseID; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_LicenseID = value;
                }
                else
                {
                    throw new ArgumentNullException("Liscense number can't be empty!");
                }
            }
        }

        public Vehicle(string i_LicenseID, string i_ModelName)
        {
            LicenseID = i_LicenseID;
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
        
        public void SetWheels(string i_ManafacturerName, float i_CurrentAirPressure)
        {
            foreach (Wheel w in m_Wheels)
            {
                w.ManufacturerName = i_ManafacturerName;
                w.CurrentAirPressure = i_CurrentAirPressure;
            }
        }
        public override string ToString() 
        {
            return string.Format(
               "License Number: {0}\nThe car model: {1}",
                LicenseID,
               ModelName
           );
        }
    }    
}
