namespace DummyJson;

class Program
{
    static async Task Main(string[] args)
    {
        ApiHandler apiHandler = new ApiHandler("https://dummyjson.com/products/");
        // CancellationTokenSource cancellationTokenSource = new();
        
        Console.Write("Adj meg egy termék azonosítót: ");
        string id = Console.ReadLine()!;
        ApiHandler.ProductResponse? productTask = await apiHandler.GetProductAsync(id);

        // var productTask = apiHandler.GetProductAsync(id, cancellationTokenSource.Token);
        // cancellationTokenSource.Cancel();

        if (productTask == null)
        {
            Console.WriteLine("Hiba a termék lekérése közben.");
        }
        else
        {
            Console.WriteLine($"Termék neve: {productTask.title}\nLeírása: {productTask.description}\nÁra: {productTask.price}$");
        }
    }
}