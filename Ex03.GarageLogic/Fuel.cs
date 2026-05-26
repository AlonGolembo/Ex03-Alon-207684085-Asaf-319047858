using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Fuel : PowerSource
    {
        public eFuelType FuelType { get; set; }
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;

        public float CurrentFuelAmount
        {
            get { return m_CurrentFuelAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The current fuel amount can't be negative!");
                }
                else if (value > m_MaxFuelAmount)
                {
                    throw new ArgumentOutOfRangeException("The current fuel amount can't be higher than max fuel amount!");
                }
                else
                {
                    m_CurrentFuelAmount = value;
                }
            }
        }

        public float MaxFuelAmount
        {
            get { return m_MaxFuelAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The max fuel amount can't be negative!");
                }
                else
                {
                    m_MaxFuelAmount = value;
                }
            }
        }
    }
}
