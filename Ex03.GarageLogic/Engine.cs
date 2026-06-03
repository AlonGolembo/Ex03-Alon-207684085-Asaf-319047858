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
                if(!(value >= 0 && value <= 100))
                {
                    throw new ValueRangeException(0f, 100f);
                }
                else
                {
                    m_EnergyPercentage = value;
                    UpdateEnergyAmount(m_EnergyPercentage);
                }
            }
        }

        public Engine() { }

        protected abstract void UpdateEnergyAmount(float i_EnergyPrecentage);
        protected void UpdateEnergyPercentage(float i_CurrentEnergyAmount, float i_MaxCapacity)
        {
            EnergyPercentage = (i_CurrentEnergyAmount / i_MaxCapacity) * 100;
        }

    }
}
