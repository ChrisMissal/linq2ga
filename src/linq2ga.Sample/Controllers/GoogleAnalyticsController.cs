using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using GoogleAnalyticsLinqProvider.Sample.Managers;
using GoogleAnalyticsLinqProvider.Sample.Models;

namespace GoogleAnalyticsLinqProvider.Sample.Controllers
{
    public class GoogleAnalyticsController : Controller
    {
        public ActionResult SignIn()
        {
            GoogleAnalyticsViewModel viewModel = new GoogleAnalyticsViewModel();
            viewModel.Url = GoogleAnalyticsServiceManager.GetRequestUrl();
            return View(viewModel);
        }

        public ActionResult Callback(string code)
        {
            GoogleAnalyticsServiceManager.SaveRefreshToken(code);
            return RedirectToAction("Index", "Index");
        }
    }
}
