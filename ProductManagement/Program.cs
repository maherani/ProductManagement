using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string connectionString = "Host=localhost;Username=postgres;Password=Admin@1403;Database=products"; // رشته اتصال به پایگاه داده

        var productRepo = new ProductRepository(connectionString);
        var newProduct = new Product
        {
            Name = "Product A",
            Price = 10.99M
        };

        int newId = await productRepo.InsertAsync(newProduct);
        Console.WriteLine($"Inserted product with ID: {newId}");
    }
}
