using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException(string i_LicenseID) 
            : base($"Vehicle with license number {i_LicenseID} doesn't exist in the garage!") { }
    }
}
