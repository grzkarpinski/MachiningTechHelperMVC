using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechHelperMVC.Application.ViewModels.Drill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Interfaces
{
    public interface IProducerService
    {
        ListProducersVM GetAllProducers();
        int AddProducer(ProducerVm producer);
        ProducerVm GetProducerForEdit(int id);
        void UpdateProducer(ProducerVm producer);
        ProducerVm GetProducerById(int producerId);
        void DeleteProducer(int producerId);
    }
}
