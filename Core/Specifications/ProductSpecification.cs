using System;
using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecfication<Product>
{
    public ProductSpecification(ProductSpecParams specParams) : base ( X =>
    (string.IsNullOrEmpty(specParams.Search) || X.Name.ToLower().Contains(specParams.Search)) &&
    (specParams.Brands.Count == 0 || specParams.Brands.Contains(X.Brand)) &&
    (specParams.Types.Count == 0 || specParams.Types.Contains(X.Type))
    )
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        
        switch (specParams.Sort)
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
