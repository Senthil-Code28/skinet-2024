using System;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data;

public class ProductRepository(StoreContext context) : IProductRepository
{
    public void AddProduct(Product product)
    {
        context.Products.Add(product);
    }

    public void DeleteProduct(Product product)
    {
        context.Products.Remove(product);
    }

    public async Task<IReadOnlyList<string>> GetBrandsAsync()
    {
        return await context.Products.Select(X => X.Brand)
            .Distinct()
            .ToListAsync();
    }

    public async Task<Product?> GetProductbyIdAsync(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, 
    string? type,string? sort)
    {
        var query = context.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(brand))
            query = query.Where(X => X.Brand == brand);

        if (!string.IsNullOrWhiteSpace(type))
            query = query.Where(X => X.Type == type);

        query = sort switch
        {
            "priceAsc" => query.OrderBy(X => X.Price),
            "priceDesc" => query.OrderByDescending(X => X.Price),
            _ => query.OrderBy(X => X.Name)
        };

        return await query.ToListAsync();

    }

    public async Task<IReadOnlyList<string>> GetTypesAsync()
    {
        return await context.Products.Select(X => X.Type)
            .Distinct()
            .ToListAsync();   
    }

    public bool ProductExists(int id)
    {
        return context.Products.Any(X => X.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0 ;
    }

    public void UpdateProduct(Product product)
    {
        context.Entry(product).State = EntityState.Modified;
    }
}
