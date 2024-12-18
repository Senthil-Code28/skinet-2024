using System;
using Core.Entities;

namespace Core.Specifications;

public class BrandListSpecification : BaseSpecfication<Product, string>
{
    public BrandListSpecification()
    {
        AddSelect(x => x.Brand);
        ApplyDistinct();
    }
}
