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

        //4. Feladat
        public int District()
        {
            if (Address.Contains("Budapest"))
            {
                string districtNumberStr = Address.Split(' ')[0];
                if (int.TryParse(districtNumberStr, out int finalDistrictValue))
                {
                    return finalDistrictValue;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            return $"{LicensePlate};{OwnerName};{Address};{Manufacturer};{Model};{CylinderCapacity}";
        }
    }
}