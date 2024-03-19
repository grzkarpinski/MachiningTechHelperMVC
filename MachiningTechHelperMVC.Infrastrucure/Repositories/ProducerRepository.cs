using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Infrastrucure.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly Context _context;

        public ProducerRepository(Context context)
        {
            _context = context;
        }
        public int AddProducer(Producer producer)
        {
            _context.Producers.Add(producer);
            _context.SaveChanges();
            return producer.Id;
        }

        public void DeleteProducer(int producerId)
        {
            var producer = _context.Producers.Find(producerId);
            if (producer != null)
            {
                _context.Producers.Remove(producer);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Producer> GetAllProducers()
        {
            return _context.Producers;
        }

        public Producer GetProducerById(int producerId)
        {
            var producer = _context.Producers.FirstOrDefault(p => p.Id == producerId);
            return producer;
        }

        public void UpdateProducer(Producer producer)
        {
            _context.Attach(producer);
            _context.Entry(producer).Property("CompanyName").IsModified = true;
            _context.SaveChanges();
        }
    }
}
