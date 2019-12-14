using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetCoders.Manager.Manager;
using DotNetCoders.Models;
using Rotativa;

namespace DotNetCoders.Controllers
{
    public class PurchaseReportController : Controller
    {
        // GET: PurchaseReport
        PurchaseManager _purchaseManager = new PurchaseManager();
        [HttpGet]
        public ActionResult Index()
        {
            PurchaseReportView purchaseReportView= new PurchaseReportView();
            purchaseReportView.startDate = DateTime.MinValue;
            purchaseReportView.endDate = DateTime.MaxValue;

            var aPurchaseReportView = new List<Model.PurchaseReportView>();
            aPurchaseReportView = _purchaseManager.PurchaseReportViews(DateTime.MinValue, DateTime.MaxValue);
            ViewBag.Message = null;
            ViewBag.Report = aPurchaseReportView;
            return View(purchaseReportView);
        }
        [HttpPost]
        public ActionResult Index(DateTime startDate, DateTime endDate)
        {
            var aPurchaseReportView = _purchaseManager.PurchaseReportViews(startDate, endDate);
            if (aPurchaseReportView.Count < 1)
            {
                ViewBag.Message = "No Data Found";
            }

            ViewBag.Report = aPurchaseReportView;
            return View();
        }
        [HttpGet]
        public ActionResult GetPurchaseReport(DateTime startDate, DateTime endDate)
        {

            var report = new ActionAsPdf("PurchaseReportPdf", new { startDate, endDate }){ FileName = "PurchaseReportPdf.pdf" };
            return report;
        }

        public ActionResult PurchaseReportPdf(DateTime startDate, DateTime endDate)
        {

            var purchaseReportViews = _purchaseManager.PurchaseReportViews(startDate, endDate);
            ViewBag.Report = purchaseReportViews;
            return View();
        }
    }
}