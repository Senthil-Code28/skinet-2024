using System;
using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecfication<Product>
{
    public ProductSpecification(string? brand, string? type,string? sort) : base ( X =>
    (string.IsNullOrWhiteSpace(brand) || X.Brand == brand) &&
    (string.IsNullOrWhiteSpace(type) || X.Type == type)
    )
    {
        switch (sort)
        {
            case "priceAsc":
                AddOrderBy(x => x.Price);
                break;
            case "priceDesc":
                AddOrderByDesending(x=> x.Price);
                break;
            default:
                AddOrderBy(x => x.Name);
                break;

        }
        
    }
}
