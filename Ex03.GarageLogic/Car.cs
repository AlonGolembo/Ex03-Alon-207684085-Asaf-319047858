using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        public ePaint Color {  get; set; }
        public eDoorsNumber DoorsNumber { get; set; }

        public Car(string i_LicenseID,
                   string i_ModelName,
                   ePaint i_Color,
                   eDoorsNumber i_DoorsNumber) : base(i_LicenseID, i_ModelName)
        {
            Color = i_Color;
            DoorsNumber = i_DoorsNumber;
        }
        public Car(string i_LicenseID,string i_ModelName) : base(i_LicenseID, i_ModelName) { }
    }


}
