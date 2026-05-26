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
            get {  return m_RemainingBatteryTime; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Remaining battery life can't be negative!");
                }
                else if (value > m_MaxBatteryTime)
                {
                    throw new ArgumentOutOfRangeException($"Remaining battery life can't exceed max battery life time: {m_MaxBatteryTime} hours!")
                }
                else
                {
                    m_MaxBatteryTime = value;
                }
            }
        }

        public ElectricEngine(float i_EnergyPercentage, float m_MaxBatteryLife) : base(i_EnergyPercentage)
        {
            MaxBatteryTime = m_MaxBatteryLife;
        }

        public void ChargeBattery(int i_ChargeHours)
        {
            if (i_ChargeHours + m_RemainingBatteryTime <= m_MaxBatteryTime)
            {
                m_RemainingBatteryTime += i_ChargeHours;
                EnergyPercentage = (m_RemainingBatteryTime / MaxBatteryTime) * 100;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Charging hours can't exceed max charging: {m_MaxBatteryTime - m_RemainingBatteryTime} hours!");
            }
        }

    }
}
