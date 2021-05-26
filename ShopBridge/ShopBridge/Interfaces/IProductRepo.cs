using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Interfaces
{
    public interface IProductRepo
    {
        Task<List<ProductMaster>> GetProductList();
        Task<ProductMaster> GetProductByID(int ProductId);
        Task<bool> AddProductDetails(ProductMaster objProduct);
        Task<bool> UpdateProductDetails(ProductMaster objProduct);
        Task<bool> DeleteProductDetails(int ProductID);
        Task<List<CategoryMaster>> GetCategoryList();
    }
}
