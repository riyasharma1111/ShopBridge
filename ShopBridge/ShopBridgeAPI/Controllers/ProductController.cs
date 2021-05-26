using ShopBridgeAPI.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopBridgeAPI.Models;
using System.Web.Http.Description;

namespace ShopBridgeAPI.Controllers
{
    public class ProductController : ApiController
    {
        private ProductBLL productbll;
        private CategoryBLL categorybll;
        public ProductController()
        {
            try
            {
                productbll = new ProductBLL();
                categorybll = new CategoryBLL();
            }
            catch (Exception ex)
            {
                throw ex;            
            }
        }

        [HttpGet]
        [ResponseType(typeof(List<ProductMaster>))]
        public IHttpActionResult GetProductDetailsList()
        {
            var data = productbll.GetProductList();
            return Ok(data);
        }
        [HttpGet]
        public ProductMaster GetProductById(int ProductId)
        {
            return productbll.GetProductDetailsById(ProductId);
        }
        [HttpPost]
        public bool AddProductDetails(ProductMaster objProduct)
        {
            return productbll.AddProductDetails(objProduct);
        }

        [HttpPut]
        public bool UpdateProductDetails(ProductMaster objProduct)
        {
            return productbll.UpdateProductDetails(objProduct);
        }
        [HttpDelete]
        public bool DeleteProductDetails(int ProductId)
        {
            return productbll.DeleteProduct(ProductId);
        }

        [HttpGet]
        public List<CategoryMaster> GetCategoryList()
        {
            return categorybll.GetCategories();
        }
    }
}
