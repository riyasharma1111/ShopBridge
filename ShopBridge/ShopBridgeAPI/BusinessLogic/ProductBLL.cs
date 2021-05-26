using ShopBridgeAPI.Interfaces;
using ShopBridgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopBridgeAPI.BusinessLogic
{
    public class ProductBLL : IProduct
    {
        private ShopBridgeEntities dbShop = new ShopBridgeEntities();
        public bool AddProductDetails(ProductMaster objProduct)
        {
            try
            {
                int count = dbShop.ProductMasters.AsQueryable().Where(x => x.ProductName == objProduct.ProductName && x.Isdeleted == false).ToList().Count();
                if (count == 0)
                {
                    ProductMaster product = new ProductMaster();
                    product.ProductName = objProduct.ProductName;
                    product.ItemNumer = objProduct.ItemNumer;
                    product.CategoryId = objProduct.CategoryId;
                    product.Weight = objProduct.Weight;
                    product.ProductDescription = objProduct.ProductDescription;
                    product.Price = objProduct.Price;
                    product.CreatedBy = 0;
                    product.CreatedOn = DateTime.Now;
                    product.Isdeleted = false;
                    dbShop.ProductMasters.Add(product);
                    dbShop.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteProduct(int ProductID)
        {
            try
            {
                ProductMaster product = GetProductDetailsById(ProductID);
                if (product != null)
                {
                    product.Isdeleted = true;
                    product.ModifiedBy = 0;
                    product.ModifiedOn = DateTime.Now;
                    dbShop.Entry(product).State = EntityState.Modified;
                    dbShop.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductMaster GetProductDetailsById(int ProductId)
        {
            try
            {
                ProductMaster product = dbShop.ProductMasters.Find(ProductId);
                if (product != null)
                {
                    return product;
                }
                else
                    return new ProductMaster();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductMaster> GetProductList()
        {
            try
            {
                var data= dbShop.ProductMasters.AsQueryable().Where(x => x.Isdeleted == false).ToList();
                return dbShop.ProductMasters.AsQueryable().Where(x => x.Isdeleted == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateProductDetails(ProductMaster objProduct)
        {
            try
            {
                ProductMaster product = GetProductDetailsById(objProduct.ProductId);
                if (product != null)
                {
                    product.ProductName = objProduct.ProductName;
                    product.ProductDescription = objProduct.ProductDescription;
                    product.ItemNumer = objProduct.ItemNumer;
                    product.Weight = objProduct.Weight;
                    product.Price = objProduct.Price;
                    product.CategoryId = objProduct.CategoryId;
                    product.ModifiedBy = 0;
                    product.ModifiedOn = DateTime.Now;
                    dbShop.Entry(product).State = EntityState.Modified;
                    dbShop.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}