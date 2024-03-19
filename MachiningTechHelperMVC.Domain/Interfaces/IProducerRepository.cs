using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface IProducerRepository
    {
        int AddProducer(Producer producer);
        Producer GetProducerById(int producerId);
        IEnumerable<Producer> GetAllProducers();
        void UpdateProducer(Producer producer);
        void DeleteProducer(int producerId);
    }
}
