using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private float m_RemainingBatteryTime;
        private float m_MaxBatteryTime;

        public float MaxBatteryTime
        {
            get {  return m_MaxBatteryTime; }
            set
            {
                if (value < 0)
                {
                    throw new ValueRangeException("Max battery life can't be negative!");
                }

                m_MaxBatteryTime = value;
            }
        }
        public float RemainingBatteryLife
        {
            get { return m_RemainingBatteryTime; }
            set
            {
                if (!(value >= 0 && value <= MaxBatteryTime))
                {
                    throw new ValueRangeException(0f, MaxBatteryTime);
                }

                m_RemainingBatteryTime = value;
            }
        }

        public ElectricEngine(float i_MaxBatteryTime)
        {
            MaxBatteryTime = i_MaxBatteryTime;
        }

       
        protected override void UpdateEnergyAmount(float i_EnergyPrecentage)
        {
            if (i_EnergyPrecentage < 0 || i_EnergyPrecentage > 100)
            {
                throw new ValueRangeException("Energy percentage can't be negative, and cant be above 100%!");
            }

            RemainingBatteryLife = (i_EnergyPrecentage / 100) * MaxBatteryTime;
        }

        public void ChargeBattery(float i_ChargeHours)
        {
            if (i_ChargeHours + m_RemainingBatteryTime > m_MaxBatteryTime)
            {
                throw new ValueRangeException($"Charging hours can't exceed max charging: {m_MaxBatteryTime - m_RemainingBatteryTime} hours!");

            }
            m_RemainingBatteryTime += i_ChargeHours;
            this.UpdateEnergyPercentage(RemainingBatteryLife, MaxBatteryTime);
        }

    }
}
