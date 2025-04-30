namespace Gepkocsi_VB_Lib
{
    public class Vehicle
    {
        //rendszam;tnev;cim;gyartmany;tipus;hurtart
        public string LicensePlate { get; init; }
        public string OwnerName { get; init; }
        public string Address { get; init; }
        public string Manufacturer { get; init; }
        public string Model { get; init; }
        public int CylinderCapacity { get; init; }

        public Vehicle(string line)
        {
            string[] splitted = line.Split(';');

            LicensePlate = splitted[0];
            OwnerName = splitted[1];
            Address = splitted[2];
            Manufacturer = splitted[3];
            Model = splitted[4];
            CylinderCapacity = int.Parse(splitted[5]);
        }
    }
}