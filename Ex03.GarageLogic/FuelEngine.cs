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
                if (!(value >= 0 && value <= TankCapacity))
                {
                    throw new ValueRangeException(0f, TankCapacity);
                }

                m_CurrentFuelAmount = value;
            }
        }

        public float TankCapacity
        {
            get { return m_TankCapacity; }
            set
            {
                if (value < 0)
                {
                    throw new ValueRangeException("The max fuel amount can't be negative!");
                }

                m_TankCapacity = value;
            }
        }

        public FuelEngine(eFuelType i_FuelType, float i_TankCapacity)
        {
            FuelType = i_FuelType;
            TankCapacity = i_TankCapacity;
        }
 
    protected override void UpdateEnergyAmount(float i_EnergyPrecentage)
    {
        if (i_EnergyPrecentage < 0 || i_EnergyPrecentage > 100)
        {
            throw new ValueRangeException("Energy percentage can't be negative, and cant be above 100%!");
        }
        CurrentFuelAmount = (i_EnergyPrecentage / 100) * TankCapacity;
    }

    public void Refuel(float i_FuelInLiters, eFuelType i_eFuelType)//Need to check 
    {
        if (m_CurrentFuelAmount + i_FuelInLiters > TankCapacity)
        {
            throw new ValueRangeException($"Fuel can't exceed tank size: {m_TankCapacity} Liters!");
        }
        CurrentFuelAmount += i_FuelInLiters;
        this.updateEnergyPercentage(CurrentFuelAmount, TankCapacity); 
    }   
  }
}

