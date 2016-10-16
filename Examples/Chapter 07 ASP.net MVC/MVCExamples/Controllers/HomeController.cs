using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCExamples.Models;

namespace MVCExamples.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult RazorSyntaxChanges()
        {
            var model = new TestModel();

            return View(model);
        }

        public ActionResult BeforeViewPortTag()
        {
            return View();
        }


        public ActionResult AfterViewPortTag()
        {
            return View();
        }

        public async Task<ActionResult> ExampleAsync()
        {
            var webClient = new WebClient();
            string html = await webClient.DownloadStringTaskAsync("http://www.google.com");
            return Content(html);
        }
    }
}
