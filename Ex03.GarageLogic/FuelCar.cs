namespace Ex03.GarageLogic
{
    public class FuelCar : Vehicle
    {
        public FuelCar(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            Engine = new FuelEngine(eFuelType.Octan95, (float)51);
            this.InitializeWheelsList(eNumberOfWheels.Five, 31);
        }
    }
}