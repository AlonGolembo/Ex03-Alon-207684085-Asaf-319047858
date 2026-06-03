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
                if(value < 0|| value > 100)
                {
                    throw new ValueRangeException("Energy percentage can't be negative, and cant be above 100%!");
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
        protected void updateEnergyPercentage(float i_CurrentFuelAmount, float i_TankCapacity)
        {
            EnergyPercentage = (i_CurrentFuelAmount / i_TankCapacity) * 100;
        }

    }
}