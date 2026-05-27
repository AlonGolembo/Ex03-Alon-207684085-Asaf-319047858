namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Vehicle
    {

        public FuelMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            this.InitializeWheelsList(eNumberOfWheels.Two, (float)30);
            this.Engine = new FuelEngine(eFuelType.Octan98, (float)1.0);
        }
    }
}