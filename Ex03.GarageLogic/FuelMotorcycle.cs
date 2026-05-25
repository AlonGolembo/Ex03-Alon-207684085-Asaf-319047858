namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : Vehicle
    {
        private string i_LicenseID;
        private string i_ModelName;

        public FuelMotorcycle(string i_LicenseID, string i_ModelName)
        {
            this.i_LicenseID = i_LicenseID;
            this.i_ModelName = i_ModelName;
        }
    }
}