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
    }
}
