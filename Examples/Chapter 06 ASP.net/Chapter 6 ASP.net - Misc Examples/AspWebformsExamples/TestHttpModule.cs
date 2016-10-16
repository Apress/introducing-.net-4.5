using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace AspWebformsExamples
{
    public class TestHttpModule : IHttpModule
    {

        public void Init(HttpApplication context)
        {
            EventHandlerTaskAsyncHelper helper = new EventHandlerTaskAsyncHelper(ScrapeHtmlPage);
            context.AddOnPostAuthorizeRequestAsync(helper.BeginEventHandler, helper.EndEventHandler);
        }

        private async Task ScrapeHtmlPage(object caller, EventArgs e)
        {
            WebClient client = new WebClient();
            var result = await client.DownloadStringTaskAsync("http://services.digg.com/2.0/digg.getAll");
            //process here
            System.Web.HttpContext.Current.Response.Write(result);
        }


        public void Dispose()
        {

        }
    }

}