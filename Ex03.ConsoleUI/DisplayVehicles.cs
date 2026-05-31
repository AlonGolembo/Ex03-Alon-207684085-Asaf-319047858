using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    internal class DisplayVehicles
    {
        internal static void Display(VehicleHandler i_VehicleHandler, eVehicleState i_VehicleState)
        {
            List<RegisteredVehicle> vehicleList = i_VehicleHandler.DisplayVehicles(i_VehicleState);
        }
    }
}