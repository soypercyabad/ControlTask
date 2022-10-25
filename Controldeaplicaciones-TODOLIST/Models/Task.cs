using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Controldeaplicaciones_TODOLIST.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Nota { get; set; }

        [Required]
        [DisplayName("Fecha/Hora Inicio")]
        public DateTime Fechacre { get; set; }

        [Required]
        public int Estado { get; set; }

        [DisplayName("Fecha/Hora Termino")]
        public DateTime Fechater { get; set; }

        [Required]
        public string Prioridad { get; set; }
        //public int status { get; set; } //1 ELIMINAR    2 ACTUALIZAR    3 COMPLETAR

    }
}

