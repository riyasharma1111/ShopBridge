using Newtonsoft.Json;
using ShopBridge.Interfaces;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;

namespace ShopBridge.BusinessLayer
{
    public class ProductBLL : IProductRepo
    {
        private MemoryCache _cache = MemoryCache.Default;
        public async Task<bool> AddProductDetails(ProductMaster objProduct)
        {
            try
            {
                using (var APIurl = GetAPIUrl())
                {
                    HttpResponseMessage response =await APIurl.PostAsJsonAsync("api/Product/AddProductDetails", objProduct); //Calling Post API for Product Details
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteProductDetails(int ProductID)
        {
            try
            {
                using (var APIurl = GetAPIUrl())
                {
                    HttpResponseMessage response = await APIurl.DeleteAsync("api/Product/DeleteProductDetails?ProductId=" + ProductID); //Calling DELETE API for Product List
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CategoryMaster>> GetCategoryList()
        {
            try
            {
                if (!_cache.Contains("CategoryList"))
                {
                    using (var Client = GetAPIUrl())
                    {
                        HttpResponseMessage response = await Client.GetAsync("api/Product/GetCategoryList");//Calling Get Category List API
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            List<CategoryMaster> CategoryList = JsonConvert.DeserializeObject<List<CategoryMaster>>(content);

                            CacheItemPolicy catchePolicy = new CacheItemPolicy();
                            catchePolicy.AbsoluteExpiration = DateTime.Now.AddDays(0.5);

                            _cache.Add("CategoryList", CategoryList, catchePolicy);
                            return CategoryList;
                        }
                        else
                        {
                            throw new ArgumentNullException();
                        }
                    }
                }
                else
                {
                    return _cache.Get("CategoryList") as List<CategoryMaster>;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductMaster> GetProductByID(int ProductId)
        {
            try
            {
                var ProductList = await GetProductList();
                var productbyId = ProductList.AsQueryable().Where(x => x.ProductId == ProductId).FirstOrDefault();
                return productbyId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductMaster>> GetProductList()
        {
            try
            {
                using (var APIurl = GetAPIUrl())
                {
                    HttpResponseMessage response = await APIurl.GetAsync("api/Product/GetProductDetailsList"); //Calling GET API for Product
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        List<ProductMaster> productlst = JsonConvert.DeserializeObject<List<ProductMaster>>(content);
                        return productlst;
                    }
                    else
                    {
                        return new List<ProductMaster>();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateProductDetails(ProductMaster objProduct)
        {
            try
            {
                using (var APIurl = GetAPIUrl())
                {
                    HttpResponseMessage response = await APIurl.PutAsJsonAsync("api/Product/UpdateProductDetails", objProduct); //Calling Update API for Product List
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static HttpClient GetAPIUrl()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44350/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}