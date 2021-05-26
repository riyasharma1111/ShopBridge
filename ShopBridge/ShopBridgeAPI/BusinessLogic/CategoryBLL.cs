using ShopBridgeAPI.Interfaces;
using ShopBridgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace ShopBridgeAPI.BusinessLogic
{
    public class CategoryBLL : ICategory
    {
        private ShopBridgeEntities dbShop = new ShopBridgeEntities();

        public List<CategoryMaster> GetCategories()
        {
            try
            {
                return dbShop.CategoryMasters.AsQueryable().Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddCategory(CategoryMaster objCategory)
        {
            try
            {
                int count = dbShop.CategoryMasters.AsQueryable().Where(x => x.CategoryName == objCategory.CategoryName && x.IsDeleted == false).ToList().Count();

                if (count == 0)
                {
                    objCategory.CreatedBy = 0;//Can insert the Id of Logged in User
                    objCategory.CreatedOn = DateTime.Now;
                    objCategory.IsDeleted = false;
                    dbShop.CategoryMasters.Add(objCategory);
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

        public bool DeleteCategory(int CategoryId)
        {
            try
            {
                CategoryMaster existingCategory = dbShop.CategoryMasters.AsQueryable().Where(x => x.IsDeleted == false && x.CategoryId == CategoryId).FirstOrDefault();

                if (existingCategory != null)
                {
                    existingCategory.ModifiedBy = 0;
                    existingCategory.ModifiedOn = DateTime.Now;
                    existingCategory.IsDeleted = true;
                    dbShop.Entry(existingCategory).State = EntityState.Modified;
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

        public CategoryMaster GetCategoryByID(int CategoryId)
        {
            try
            {
                CategoryMaster Categories = dbShop.CategoryMasters.Find(CategoryId);
                if (Categories != null)
                {
                    return Categories;
                }
                else
                {
                    return new CategoryMaster();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCategory(CategoryMaster objCategory)
        {
            try
            {
                CategoryMaster existingCategory = dbShop.CategoryMasters.AsQueryable().Where(x => x.IsDeleted == false && x.CategoryId == objCategory.CategoryId).FirstOrDefault();

                if (existingCategory != null)
                {
                    existingCategory.CategoryName = objCategory.CategoryName;
                    existingCategory.ModifiedBy = 0;
                    existingCategory.ModifiedOn = DateTime.Now;
                    existingCategory.IsDeleted = false;
                    dbShop.Entry(existingCategory).State = EntityState.Modified;
                    dbShop.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}