using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using Controldeaplicaciones_TODOLIST.Models;
using Controldeaplicaciones_TODOLIST.ServiceReferenceTask;
using Task = Controldeaplicaciones_TODOLIST.ServiceReferenceTask.Task;

namespace Controldeaplicaciones_TODOLIST.Controllers 
{
    public class WCFController : Controller 
    {
        // GET: WCF
        public ActionResult Index()
        {
            //Devuelve la vista del index 
            return View();
        }

        public JsonResult Listtask()
        {
            ServiceReferenceTask.TaskClient srt = new ConectionWcf().Conectar();
            var list = srt.GetTasks();
            //Devuelve la vista del index 
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListPrioridad(string filtro)
        {
            ServiceReferenceTask.TaskClient srt = new ConectionWcf().Conectar();
            var list = srt.ListPriority(filtro);
            //Devuelve la vista del index 
            return Json(list, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetDatos(int id)
        {
            ServiceReferenceTask.TaskClient srt = new ConectionWcf().Conectar();
            var list = srt.ListId(id);
            //Devuelve la vista del index 
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertTask(Task itask)
        {
            ServiceReferenceTask.TaskClient srt = new ConectionWcf().Conectar();
            srt.InsertTask(itask);
            return Json(itask);
        }

        public JsonResult EditTask(Task itask)
        {
            ServiceReferenceTask.TaskClient srt = new ConectionWcf().Conectar();
            srt.EditTask(itask);
            return Json(itask);
        }

        public JsonResult ChangeStatusTask(int id)
        {
            ServiceReferenceTask.TaskClient srt = new ConectionWcf().Conectar();
            srt.ChangeStatusTask(id);
            return Json(id);
        }

        public JsonResult DeleteTask(int id)
        {
            ServiceReferenceTask.TaskClient srt = new ConectionWcf().Conectar();
            srt.DeleteTask(id);
            return Json(id);
        }
    }
}