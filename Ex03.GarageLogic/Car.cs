using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        
        public ePaint? Color {  get; set; }
        public eDoorsNumber? DoorsNumber { get; set; }

        public Car(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            Color = null;
            DoorsNumber = null;
        }
        public Car(string i_LicenseID,
                   string i_ModelName,
                   ePaint i_Color,
                   eDoorsNumber i_DoorsNumber) : base(i_LicenseID, i_ModelName)
        {
            Color = i_Color;
            DoorsNumber = i_DoorsNumber;
        }

        public override bool InsertSpecificVehicleProperties(string i_Property1, string i_Property2)
        {
            bool canInsert = false;
            if (!ePaint.TryParse(i_Property1, out ePaint paint))
            {
                throw new FormatException("Can't parse paint to enum!");
            }
            if (!Enum.IsDefined(typeof(ePaint), paint))
            {
                throw new ArgumentException("Enum isn't defined!");
            }
            Color = paint;

            if (!eDoorsNumber.TryParse(i_Property2, out eDoorsNumber doorsNumber))
            {
                throw new FormatException("Can't parse doors number to enum!");
            }
            if (!Enum.IsDefined(typeof(eDoorsNumber), doorsNumber))
            {
                throw new ArgumentException("Enum isn't defined!");
            }
            DoorsNumber = doorsNumber;

            return canInsert;
        }
    }
}
