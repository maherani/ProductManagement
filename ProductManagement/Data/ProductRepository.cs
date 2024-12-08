using Npgsql; // برای استفاده از درایور PostgreSQL
using System; // برای استفاده از کلاس‌های پایه
using System.Data; // برای استفاده از IDbConnection
using System.Threading.Tasks; // برای استفاده از Task در متدهای ناهمگام

public class ProductRepository
{
    private readonly string _connectionString; // رشته اتصال به پایگاه داده

    public ProductRepository(string connectionString)
    {
        _connectionString = connectionString; // ذخیره رشته اتصال
    }

    public async Task<int> InsertAsync(Product product)
    {
        using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
        {
            string query = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price) RETURNING Id;";
            dbConnection.Open(); // باز کردن اتصال
            var id = await dbConnection.ExecuteScalarAsync<int>(query, new { product.Name, product.Price });
            return id; // برگرداندن شناسه محصول جدید
        }
    }
}
