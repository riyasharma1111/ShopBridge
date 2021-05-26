using ShopBridgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Interfaces
{
    public interface ICategory
    {
        List<CategoryMaster> GetCategories();
        CategoryMaster GetCategoryByID(int CategoryId);
        bool AddCategory(CategoryMaster objCategory);
        bool UpdateCategory(CategoryMaster objCategory);
        bool DeleteCategory(int CategoryId);        
    }
}
