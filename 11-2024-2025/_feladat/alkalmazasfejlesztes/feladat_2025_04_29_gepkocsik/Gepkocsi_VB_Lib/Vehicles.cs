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
    }
}
