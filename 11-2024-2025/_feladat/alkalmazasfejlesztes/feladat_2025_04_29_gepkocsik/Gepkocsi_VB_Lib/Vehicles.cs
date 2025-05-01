namespace Gepkocsi_VB_Lib
{
    public class Vehicles
    {
        private readonly List<Vehicle> vehiclesList = new();

        public Vehicles(IEnumerable<string> dataLines)
        {
            foreach (var item in dataLines)
            {
                vehiclesList.Add(new (item));
            }
        }

        public IEnumerable<Vehicle> List => vehiclesList;

        //3. Feladat
        public int Count => vehiclesList.Count;

        //5. Feladat
        public int budapestCount => vehiclesList.Count(x => x.District() != -1);
        public int ruralCount => vehiclesList.Count(x => x.District() == -1);

        //6. Feladat
        public double AverageCylinderCapacity =>
            Math.Round(vehiclesList
                .Where(x => x.District() != -1)
                .Select(x => x.CylinderCapacity)
                .Average() / 1000, 2);

        //7. Feladat
        public string ManufacturerWithLeastVehicles => vehiclesList.MinBy(x => x.Manufacturer).Manufacturer;

        //8. Feladat
        public IEnumerable<Vehicle> VehiclesByManufacturer(string manufacturer) => vehiclesList.Where(x => x.Manufacturer == manufacturer);
    }
}
