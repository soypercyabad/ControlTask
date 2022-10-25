using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfTask
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ITask
    {
        [OperationContract]
        List<Task> GetTasks();

        [OperationContract]
        List<Task> ListPriority(string filtro);

        [OperationContract]
        List<Task> ListId(int id);

        [OperationContract]
        void InsertTask(Task task);

        [OperationContract]
        void EditTask(Task task);

        [OperationContract]
        void ChangeStatusTask(int id);

        [OperationContract]
        void DeleteTask(int id);

        //[OperationContract]
        //void Conectar();

        //[OperationContract]
        //void Desconectar();
        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Task
    {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Nota { get; set; }

        [DataMember]
        public DateTime Fechacre { get; set; }

        [DataMember]
        public int Estado { get; set; }

        [DataMember]
        public DateTime Fechater { get; set; }

        [DataMember]
        public string Prioridad { get; set; }
    }
}
