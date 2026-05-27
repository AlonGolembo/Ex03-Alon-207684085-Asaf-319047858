using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public eFuelType FuelType { get; set; }
        private float m_CurrentFuelAmount;
        private float m_TankCapacity;

        public float CurrentFuelAmount
        {
            get { return m_CurrentFuelAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The current fuel amount can't be negative!");
                }
                else if (value > m_TankCapacity)
                {
                    throw new ArgumentOutOfRangeException("The current fuel amount can't be higher than max fuel amount!");
                }
                else
                {
                    m_CurrentFuelAmount = value;
                }
            }
        }

        public float TankCapacity
        {
            get { return m_TankCapacity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The max fuel amount can't be negative!");
                }
                else
                {
                    m_TankCapacity = value;
                }
            }
        }

        public FuelEngine(eFuelType i_FuelType, float i_TankCapacity)
        {
            FuelType = i_FuelType;
            TankCapacity = i_TankCapacity;
        }

        public FuelEngine(eFuelType i_FuelType, float i_TankCapacity, float i_CurrentFuelAmount)
        {
            FuelType = i_FuelType;
            TankCapacity = i_TankCapacity;
            CurrentFuelAmount = i_CurrentFuelAmount;
            this.UpdateEnergyPercentage(CurrentFuelAmount, TankCapacity);
        }

        public void Refuel(float i_FuelInLiters, eFuelType i_eFuelType)
        {
            if (FuelType != i_eFuelType)
            {
                throw new ArgumentException("Fuel type has to match to car's fuel type!");
            }

            if (m_CurrentFuelAmount + i_FuelInLiters <= m_TankCapacity)
            {
                m_CurrentFuelAmount += i_FuelInLiters;
                this.UpdateEnergyPercentage(CurrentFuelAmount, TankCapacity); // Update the energy percentage whenver refuling
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Feul can't exceed tank size: {m_TankCapacity} Liters!");
            }

        }
    }
}
