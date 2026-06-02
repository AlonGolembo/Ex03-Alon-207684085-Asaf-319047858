namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        public ElectricCar(string i_LicenseID,
                           string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            Engine = new ElectricEngine((float)4.6);
            this.InitializeWheelsList(eNumberOfWheels.Five, 31);
        }

        public ElectricCar(string i_LicenseID,
                           string i_ModelName,
                           ePaint i_Color,
                           eDoorsNumber i_DoorsNumber) : base(i_LicenseID, i_ModelName, i_Color, i_DoorsNumber)
        {
            Engine = new ElectricEngine((float)4.6);
            this.InitializeWheelsList(eNumberOfWheels.Five, 31);
        }
    }
}