using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Controldeaplicaciones_TODOLIST.Models
{
    public class ConectionWcf
    {
        public ServiceReferenceTask.TaskClient Conectar()
        {
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.None;
            binding.Name = "MetadataExchangeHttpBinding_ITask";
            EndpointAddress endpointAddress = new EndpointAddress("http://localhost:49913/ServiceTask.svc/mex");
            return new ServiceReferenceTask.TaskClient(binding, endpointAddress);
        }
    }
}