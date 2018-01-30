using System.Collections.Generic;
using SIENN.Domain;

namespace SIENN.Services.Products
{
    public interface IProductService
    {
        List<Product> GetAvailableProductsWithMoreThanOneCategory();
        List<Product> GetNotAvailableProductsWhichDeliveryIsPlanedInCurrentMonth();
        Product GetProduct(int id);
        Product UpdateProduct(Product product);
        Product CreateProduct(Product product);
        IList<Product> GetAvailableProducts(int skip, int take);
        IList<Product> GetFilteredProducts(int productTypeId, int unitId, int categoryId, int skip, int take);
    }
}