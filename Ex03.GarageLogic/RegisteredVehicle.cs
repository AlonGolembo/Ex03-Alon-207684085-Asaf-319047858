using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class RegisteredVehicle
    {
        public Vehicle Vehicle {  get; set; }
        private string m_OwnerName { get; set; }
        private string m_OwnerPhoneNumber;
        public eVehicleState m_VehicleState { get; set; }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                    {
                        throw new ArgumentException("Owner name can contain only letters!");
                    }
                }
            }
        }
        public string OwnerPhoneNumber
        {
            get { return  m_OwnerPhoneNumber; }
            set
            {
                if (!value.StartsWith("05"))
                {
                    throw new FormatException("Phone number must start with 05!");
                }

                for (int i = 0; i < value.Length; i++)
                {
                    if (!(char.IsDigit(value[i]) || value[i] == '-'))
                    {
                        throw new FormatException($"{i} is not valid.");
                    }
                }
            }
        }

        public RegisteredVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            Vehicle = i_Vehicle;
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhoneNumber;
        }
    }
}
