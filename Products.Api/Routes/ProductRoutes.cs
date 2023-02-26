namespace Products.Api.Routes;
using Products.Api.Models;
public class ProductRoutes
{
    internal string GetProductsRoute = "api/products";
    internal string GetProductByIdRoute = "api/products/{id}";
    internal string CreateProductRoute = "api/products";
    internal string UpdateProductRoute = "api/products/{id}";
    internal string DeleteProductRoute = "api/products/{id}";

    public void RegisterProductRoutes(WebApplication app)
    {
        app.MapGet(GetProductsRoute, () => Product.SampleData());

        app.MapGet(GetProductByIdRoute, (int id) =>
            Product.SampleData().FirstOrDefault(a => a.Id == id) is { } product
                ? Results.Ok(product)
                : Results.NotFound());
        app.MapPost(CreateProductRoute, (Product product) =>
        {
            var finalProduct = product with
            {
                Id = Product.SampleData().Max(a => a.Id) + 1
            };
            Product.SampleData().Add(finalProduct);
            return Results.Created($"/products/{finalProduct.Id}", finalProduct);
        });
        app.MapPut(UpdateProductRoute, (int id, Product product) =>
        {
            var existingProduct = Product.SampleData().FirstOrDefault(a => a.Id == id);
            if (existingProduct is null)
            {
                return Results.NotFound();
            }
            var finalProduct = existingProduct with
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
            return Results.Ok(finalProduct);
        });
        app.MapDelete(DeleteProductRoute, (int id) =>
        {
            var product = Product.SampleData().FirstOrDefault(a => a.Id == id);
            if (product is null)
            {
                return Results.NotFound();
            }
            Product.SampleData().ToList().Remove(product);
            return Results.NoContent();
        });
    }
}