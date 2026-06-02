namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle(string i_LicenseID,
                                  string i_ModelName,
                                  int i_EngineCapacity,
                                  eDrivingLicenceCategory i_DrivingLicenceCategory) : base(i_LicenseID, i_ModelName, i_EngineCapacity, i_DrivingLicenceCategory)
        { 
            this.InitializeWheelsList(eNumberOfWheels.Two, (float)30);
            this.Engine = new ElectricEngine((float)3.0);
        }
    }
}