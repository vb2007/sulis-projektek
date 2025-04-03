namespace Hoember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HoEmber ho1 = new HoEmber();
            Console.WriteLine(ho1.Info());

            HoEmber ho2 = new HoEmber();
            ho2.Olvad(30);
            Console.WriteLine(ho2.Info());
            ho2.Visszafagy(10);
            Console.WriteLine(ho2.Info());


            List<HoEmber> list = new List<HoEmber>();

            foreach (var item in File.ReadLines("ho.csv").Skip(1))
            {
                list.Add(new HoEmber(item));
            }

            foreach (var item in list)
            {
                Console.WriteLine();
                Console.WriteLine(item.Info());
            }
        }
    }
}
