namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Vehicle
    {
        public ElectricMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            this.InitializeWheelsList(eNumberOfWheels.Two, (float)30);
            this.Engine = new ElectricEngine((float)3.0);
        }
    }
}