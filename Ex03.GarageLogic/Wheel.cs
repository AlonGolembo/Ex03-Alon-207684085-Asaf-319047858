using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_ManufacturerName = value;
                }
                else
                {
                    throw new ArgumentNullException("Manufacturer name can't be empty!");
                }
            }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                if (value >= 0 && value <= MaxAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Current amount of air must be positive and not exceed max air pressure!");
                }
            }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set
            {
                if (value > 0)
                {
                    m_MaxAirPressure = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Max mount of air can't be negative!");
                }
            }
        }

        public Wheel()
        {
            ManufacturerName = string.Empty;
            CurrentAirPressure = 0;
            MaxAirPressure = 0;
        }

        public Wheel(float i_MaxAirPressure)
        {
            ManufacturerName = string.Empty;
            CurrentAirPressure = 0;
            MaxAirPressure = i_MaxAirPressure;
        }

        public void Inflate(float i_AirToAdd)
        {
            if (i_AirToAdd > 0 && CurrentAirPressure + i_AirToAdd <= MaxAirPressure)
            {
                CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                throw new ArgumentOutOfRangeException( "Amount of air to add must be positive and not exceed max air pressure!");
            }
        }

    }
}