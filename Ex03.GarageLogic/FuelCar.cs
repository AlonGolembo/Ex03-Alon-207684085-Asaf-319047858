namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        public FuelCar(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            Engine = new FuelEngine(eFuelType.Octan95, (float)51);
            this.InitializeWheelsList(eNumberOfWheels.Five, 31);
        }

        public FuelCar(string i_LicenseID,
                       string i_ModelName,
                       ePaint i_Color,
                       eDoorsNumber i_DoorsNumber) : base(i_LicenseID, i_ModelName, i_Color, i_DoorsNumber)
        {
            Engine = new FuelEngine(eFuelType.Octan95, (float)51);
            this.InitializeWheelsList(eNumberOfWheels.Five, 31);
        }
    }
}