namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        public FuelMotorcycle(string i_LicenseID,
                              string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            this.InitializeWheelsList(eNumberOfWheels.Two, (float)30);
            this.Engine = new FuelEngine(eFuelType.Octan98, (float)1.0);
        }
        public FuelMotorcycle(string i_LicenseID,
                              string i_ModelName,
                              int i_EngineCapacity,
                              eDrivingLicenceCategory i_DrivingLicenceCategory) : base(i_LicenseID, i_ModelName, i_EngineCapacity, i_DrivingLicenceCategory)
        {
            this.InitializeWheelsList(eNumberOfWheels.Two, (float)30);
            this.Engine = new FuelEngine(eFuelType.Octan98, (float)1.0);
        }
    }
}