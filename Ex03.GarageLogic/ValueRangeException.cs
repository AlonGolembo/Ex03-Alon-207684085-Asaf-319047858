using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueRangeException : Exception
    {
        private readonly float m_MinValue;
        private readonly float m_MaxValue;
        public ValueRangeException() : base("Value is out of range.")
        {
        }
        public ValueRangeException(string i_Message) : base(i_Message)
        {
        }
        public ValueRangeException(string i_Message,Exception i_InnerException) : base(i_Message, i_InnerException)    
        {    
        }

        public ValueRangeException(float i_MinValue, float i_MaxValue,string i_Message)
            : base(i_Message)
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
