using Controldeaplicaciones_TODOLIST.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controldeaplicaciones_TODOLIST.Controllers
{
    public class HomeController : Controller
    {
        List<Task> lstTask = new List<Task>();
        public ActionResult Index()
        {
            //Devuelve la vista del index 
            return View();

        }

        //Retornar objeto en formato json
        [HttpPost]
        public JsonResult Llenartabla(Task _ojbTask)
        {

            #region data

            //Datos creados por que no guarda en la lista

            lstTask.Add(new Task
            {
                Id = 1,
                Nombre = "Html",
                Fechacre = DateTime.Now,
                Estado = false,
                Fechater = new DateTime(2022, 11, 12, 14, 15, 16)
            });

            lstTask.Add(new Task
            {
                Id = 2,
                Nombre = "Css",
                Fechacre = DateTime.Now,
                Estado = true,
                Fechater = new DateTime(2022, 02, 08, 20, 07, 06)
            });

            lstTask.Add(new Task
            {
                Id = 3,
                Nombre = "Base de Datos",
                Fechacre = DateTime.Now,
                Estado = false,
                Fechater = new DateTime(2022, 02, 08, 17, 00, 16)
            });

            lstTask.Add(new Task
            {
                Id = 4,
                Nombre = "JavaScript",
                Fechacre = DateTime.Now,
                Estado = false,
                Fechater = new DateTime(2022, 02, 08, 21, 00, 16)
            });

            lstTask.Add(new Task
            {
                Id = 5,
                Nombre = "Boostrap",
                Fechacre = DateTime.Now,
                Estado = true,
                Fechater = new DateTime(2022, 02, 08, 13, 00, 16)
            });

            lstTask.Add(new Task
            {
                Id = 6,
                Nombre = "Php",
                Fechacre = DateTime.Now,
                Estado = true,
                Fechater = new DateTime(2022, 02, 08, 18, 00, 16)
            });

            #endregion
            return Json(lstTask);

        }

        [HttpPost]
        public JsonResult Agregar(Task _ojbTask)
        {
            //Agregar Datos
            int list_count = lstTask.Count;

            _ojbTask.Id = list_count + 1;
            lstTask.Add(_ojbTask);
            //Retorna las listas
            return Json(lstTask);
        }

        [HttpPost]
        public JsonResult Status(Task _ojbTask)
        {
            //Datos creados por que no guarda en la lista
            //lstTask.Add(new Task
            //{
            //    Id = 1,
            //    Nombre = "JavaScript",
            //    Fechacre = DateTime.Now,
            //    Estado = false,
            //    Fechater = new DateTime(2022, 02, 08, 21, 00, 16)
            //});

            foreach (var item in lstTask)
            {
                if (item.Id == _ojbTask.Id)
                {
                    //Cambiar estado
                    item.Estado = true;
                }
            }
            return Json(lstTask); ;
        }

        [HttpPost]
        public JsonResult Actualizar(Task Task)
        {
            //Datos creados por que no guarda en la lista
            //lstTask.Add(new Task
            //{
            //    Id = 1,
            //    Nombre = "Html",
            //    Fechacre = DateTime.Now,
            //    Estado = false,
            //    Fechater = new DateTime(2022, 11, 12, 14, 15, 16)
            //});

            Task _ojbTask = new Task();

            foreach (var item in lstTask)
            {
                if (item.Id == Task.Id)
                {
                    _ojbTask.Id = item.Id;
                    _ojbTask.Nombre = item.Nombre;
                    _ojbTask.Fechacre = item.Fechacre;
                }
            }
            return Json(_ojbTask);
        }

        [HttpPost]
        public JsonResult Editar(Task _ojbTask)
        {
            //Dato agregado por que no guarda en lista
            //lstTask.Add(new Task
            //{
            //    Id = 1,
            //    Nombre = "Html",
            //    Fechacre = DateTime.Now,
            //    Estado = false,
            //    Fechater = new DateTime(2022, 11, 12, 14, 15, 16)
            //});

            foreach (var item in lstTask)
            {
                if (item.Id == _ojbTask.Id)
                {
                    _ojbTask.Id = item.Id;
                    _ojbTask.Nombre = item.Nombre;
                    _ojbTask.Fechacre = item.Fechacre;
                }
            }
            return Json(lstTask);
        }

        [HttpPost]
        public JsonResult Eliminar(Task _ojbTask)
        {
            foreach (var item in lstTask)
            {
                if (item.Id == _ojbTask.Id)
                {
                    //Eliminar 
                    lstTask.Remove(item);
                }
            }
            return Json(lstTask);
        }

    }
}