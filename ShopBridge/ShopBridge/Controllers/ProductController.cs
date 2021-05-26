using ShopBridge.BusinessLayer;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopBridge.Controllers
{
    public class ProductController : Controller
    {
        private ProductBLL productbll;
        public ProductController()
        {
            productbll = new ProductBLL();
        }
        // GET: Product
        public async Task<ActionResult> Index()
        {
            if (Session["CategoryList"] == null)
            {
                Session["CategoryList"] = await productbll.GetCategoryList();
            }
            return View(await productbll.GetProductList());
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await productbll.GetCategoryList(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductId,ProductName,ItemNumer,ProductDescription,CategoryId,Price,Weight,Isdeleted,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy")] ProductMaster product)
        {
            ViewBag.CategoryId = new SelectList(await productbll.GetCategoryList(), "CategoryId", "CategoryName", product.CategoryId);
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await productbll.AddProductDetails(product);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new HttpUnhandledException();
                    }
                }
                return View(product);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Edit(int? Productid)
        {
            ViewBag.CategoryId = new SelectList(await productbll.GetCategoryList(), "CategoryId", "CategoryName");
            if (Productid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = await productbll.GetProductByID((int)Productid);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductId,ProductName,ItemNumer,ProductDescription,CategoryId,Price,Weight,Isdeleted,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy")] ProductMaster product)
        {
            try
            {
                ViewBag.Category_Id = new SelectList(await productbll.GetCategoryList(), "CategoryId", "CategoryName", product.CategoryId);
                if (ModelState.IsValid)
                {
                    var result = await productbll.UpdateProductDetails(product);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new HttpUnhandledException();
                    }
                }
                return View(product);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ActionResult> Delete(int? ProductId)
        {
            if (ProductId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session["CategoryList"] == null)
            {
                Session["CategoryList"] = await productbll.GetCategoryList();
            }
            var product = await productbll.GetProductByID((int)ProductId);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(await productbll.GetCategoryList(), "CategoryId", "CategoryName");
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int ProductId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await productbll.DeleteProductDetails((int)ProductId);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new HttpUnhandledException();
                    }
                }
                else
                    return RedirectToAction("Delete", ProductId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}