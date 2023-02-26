using System.Security.Cryptography;
namespace Products.Api.Models;

public record class Product(int Id, string Name, string Description, decimal Price, Category Category)
{
    public static Product Create(int id, string name, string description, decimal price, Category category)
        => new(id, name, description, price, category);
    public static IList<Product> SampleData()
    {
        return Enumerable.Range(1, 10)
            .Select(i => Product.Create(i,
                $"Product {i}",
                $"Description {i}",
                i * 10,
                (Category)RandomNumberGenerator.GetInt32(0, 4))).ToList();
    }
}
public enum Category
{
    Electronics = 0,
    Books = 1,
    Clothing = 2,
    Food = 3,
    Other = 4
}
