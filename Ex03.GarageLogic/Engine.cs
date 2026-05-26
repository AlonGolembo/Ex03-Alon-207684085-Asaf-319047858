using System;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_EnergyPercentage;

        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Energy percentage can't be negative!");
                }
                else
                {
                    m_EnergyPercentage = value;
                }
            }
        }

        public Engine(float i_EnergyPercentage)
        {
            EnergyPercentage = i_EnergyPercentage;
        }
    }
}