using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float m_MinValue;
        private readonly float m_MaxValue;
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base($"Value is out of range. It should be between {i_MinValue} and {i_MaxValue}.")
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
        public float MinValue
        {
            get { return m_MinValue; }
        }
        public float MaxValue
        {
            get { return m_MaxValue; }
        }
    }
}
