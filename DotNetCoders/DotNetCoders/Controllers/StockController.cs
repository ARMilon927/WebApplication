using DotNetCoders.Manager.Manager;
using DotNetCoders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;

namespace DotNetCoders.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        private StockManager _stockManager = new StockManager();

        [HttpGet]
        public ActionResult Index()
        {
            StockViewModel model = new StockViewModel();

            model.startDate = DateTime.Today.Date;
            model.endDate = DateTime.Today.Date;

            model.Categories = _categoryManager.GetAll();
            model.Stocks = _stockManager.StockReports(null,null, model.startDate, model.endDate).Where(x => x.In != 0 || x.Out != 0 || x.OpeningBalance !=0 || x.ClosingBalance !=0).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int? categoryId, int? productId,DateTime startDate, DateTime endDate)
        {
            StockViewModel model = new StockViewModel();
            model.Categories = _categoryManager.GetAll();
           
              model.Stocks = _stockManager.StockReports(categoryId, productId, startDate, endDate).Where(x => x.In != 0 || x.Out != 0 || x.OpeningBalance != 0 || x.ClosingBalance != 0).ToList();
             
            return View(model);
        }

        public JsonResult GetProductByCategoryId(int categoryId)
        {
        
            var ProductList = _productManager.GetAll().Where(c => c.CategoryId == categoryId).ToList();
            var Products = ProductList.Select(c => new { c.Id, c.Name }).ToList();
            return Json(Products, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index(int categoryId)
        {
            StockViewModel model = new StockViewModel();
            model.Categories = _categoryManager.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult GetStockReport(int? categoryId, int? productId, DateTime startDate, DateTime endDate)
        {

            var report = new ActionAsPdf("StockReportPdf", new {categoryId, productId, startDate, endDate }) { FileName = "SalesReportPdf.pdf" };
            return report;
        }

        public ActionResult StockReportPdf(int? categoryId, int? productId, DateTime startDate, DateTime endDate)
        {
            StockViewModel model = new StockViewModel();
            model.Stocks = _stockManager.StockReports(categoryId, productId, startDate, endDate).Where(x => x.In != 0 || x.Out != 0 || x.OpeningBalance != 0 || x.ClosingBalance != 0).ToList(); ;
            
            return View(model);
        }
    }
}