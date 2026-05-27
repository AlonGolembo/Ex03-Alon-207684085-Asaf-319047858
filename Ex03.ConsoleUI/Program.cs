using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        public static void Main()
        {
            // Test VehicleDatabaseLoader class

            Console.WriteLine("Going to test the VehicleDatabaseLoader class now...");
            Console.WriteLine();
            VehicleDatabaseLoader.Load("VehiclesDB.txt");

        }
    }
}
