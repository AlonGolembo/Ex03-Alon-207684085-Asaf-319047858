namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        public ElectricCar(string i_LicenseID, string i_ModelName) : base (i_LicenseID, i_ModelName)
        {
            Engine = new ElectricEngine((float)4.6);
            this.InitializeWheelsList(eNumberOfWheels.Five, 31);
        }
    }
}