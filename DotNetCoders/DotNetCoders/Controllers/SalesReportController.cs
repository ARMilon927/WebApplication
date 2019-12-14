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
    public class SalesReportController : Controller
    {
        // GET: SalesReport
        SalesManager _salesManager = new SalesManager();
        [HttpGet]
        public ActionResult Index()
        {
            SalesReportView aSalesReportView = new SalesReportView();
            aSalesReportView.startDate = DateTime.MinValue;
            aSalesReportView.endDate = DateTime.MaxValue;
            var salesReportViews = _salesManager.SalesReportViews(DateTime.MinValue, DateTime.MaxValue);
            ViewBag.Message = null;
            ViewBag.Report = salesReportViews;
            return View(aSalesReportView);
        }
        [HttpPost]
        public ActionResult Index(DateTime startDate, DateTime endDate)
        {
            var salesReportViews = _salesManager.SalesReportViews(startDate, endDate);
            if (salesReportViews.Count < 1)
            {
                ViewBag.Message = "No Data Found";
            }

            ViewBag.Report = salesReportViews;
            return View();
        }
        [HttpGet]
        public ActionResult GetSalesReport(DateTime startDate, DateTime endDate)
        {

            var report = new ActionAsPdf("SalesReportPdf", new{ startDate , endDate }) { FileName = "SalesReportPdf.pdf" };
            return report;
        }

        public ActionResult SalesReportPdf(DateTime startDate, DateTime endDate)
        {

            var salesReportViews = _salesManager.SalesReportViews(startDate,endDate);
            ViewBag.Report = salesReportViews;
            return View();
        }
    }
}