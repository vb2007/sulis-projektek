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

        Console.Write("\nAdj meg egy kategóriát (pl. smartphones): ");
        string category = Console.ReadLine()!;
        ApiHandler.CountResponse? countTask = await apiHandler.GetCategoryCountAsync(category);

        if (countTask == null)
        {
            Console.WriteLine("Hiba a termékszám lekérése közben.");
        }
        else
        {
            Console.WriteLine($"Termékek száma a kategóriában: {countTask.total}");
        }

        ApiHandler.ProductListResponse? productListTask = await apiHandler.GetCategoryProductsAsync(category);

        if (productListTask == null)
        {
            Console.WriteLine("Hiba a termékek lekérése közben.");
        }
        else
        {
            foreach (ApiHandler.ProductResponse product in productListTask.products)
            {
                Console.WriteLine($"- {product.title} ({product.price}$)");
            }
        }
    }
}