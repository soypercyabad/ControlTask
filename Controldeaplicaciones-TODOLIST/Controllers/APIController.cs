using Controldeaplicaciones_TODOLIST.Models;
using Controldeaplicaciones_TODOLIST.ServiceReferenceTask;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Controldeaplicaciones_TODOLIST.Controllers
{
    public class APIController : Controller
    {
        // GET: API
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> Listtask()
        {
            //https://localhost:44346/api/WebApiTask
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44346/api/WebApiTask");
            //Devuelve la vista del index ); 
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}