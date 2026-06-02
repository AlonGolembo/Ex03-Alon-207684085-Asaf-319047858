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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Manufacturer name can't be empty!");
                }

                m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                if (!(value >= 0 && value <= MaxAirPressure))
                {
                    throw new ValueRangeException(0f, MaxAirPressure);
                }

                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set
            {
                if (value < 0)
                {
                    throw new ValueRangeException("Max mount of air can't be negative!");
                }

                m_MaxAirPressure = value;
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
            if (!(i_AirToAdd > 0 && CurrentAirPressure <= (MaxAirPressure - i_AirToAdd)))
            {
                throw new ValueRangeException(0f, (MaxAirPressure - i_AirToAdd));
            }

            CurrentAirPressure += i_AirToAdd;
        }
    }
}