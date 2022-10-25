using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiTask.Models;
using WebApiTask.ServiceReference1;

namespace WebApiTask.Controllers
{
    public class WebApiTaskController : ApiController
    {
        // GET: api/WebApiTask
        public IEnumerable<ServiceReference1.Task> Get()
        {
            List<ServiceReference1.Task> list1 = new List<ServiceReference1.Task>();

            ServiceReference1.TaskClient srt = new ConectionWCF().Conectar();
            var list = srt.GetTasks();

            foreach (var item in list)
            {
                ServiceReference1.Task task1 = new ServiceReference1.Task()
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Nota = item.Nota,
                    Fechacre = item.Fechacre,
                    Estado = item.Estado,
                    Fechater = item.Fechater,
                    Prioridad = item.Prioridad
                };
                list1.Add(task1);
            }

            return list;
        }

        //// GET: api/WebApiTask/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/WebApiTask
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/WebApiTask/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/WebApiTask/5
        //public void Delete(int id)
        //{
        //}
    }
}
