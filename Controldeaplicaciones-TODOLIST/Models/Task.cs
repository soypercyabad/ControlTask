using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackExchange.Redis;

namespace Controldeaplicaciones_TODOLIST.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fechacre { get; set; }
        public bool Estado { get; set; }
        public DateTime? Fechater { get; set; }
        //public int status { get; set; } //1 ELIMINAR    2 ACTUALIZAR    3 COMPLETAR
    }
}