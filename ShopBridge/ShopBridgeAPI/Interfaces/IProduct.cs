using ShopBridgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Interfaces
{
    public interface IProduct
    {
        List<ProductMaster> GetProductList();
        ProductMaster GetProductDetailsById(int ProductId);
        bool AddProductDetails(ProductMaster objProduct);
        bool UpdateProductDetails(ProductMaster objProduct);
        bool DeleteProduct(int ProductID);
    }
}
