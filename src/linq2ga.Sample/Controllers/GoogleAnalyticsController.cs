using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using linq2ga.Sample.Managers;
using linq2ga.Sample.Models;

namespace linq2ga.Sample.Controllers
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
