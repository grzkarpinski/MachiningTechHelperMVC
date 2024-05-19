using AutoMapper;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechHelperMVC.Domain.Interfaces;

namespace MachiningTechelperMVC.Application.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepo;
        private readonly IMapper _mapper;

        public ProducerService(IProducerRepository producerRepo, IMapper mapper)
        {
            _producerRepo = producerRepo;
            _mapper = mapper;
        }

        public int AddProducer(ProducerVm producer)
        {
            var producerToAdd = _mapper.Map<MachiningTechHelperMVC.Domain.Model.Producer>(producer);
            var id = _producerRepo.AddProducer(producerToAdd);
            return id;
        }

        public void DeleteProducer(int producerId)
        {
            _producerRepo.DeleteProducer(producerId);
        }

        public ListProducersVM GetAllProducers()
        {
            var producers = _producerRepo.GetAllProducers();
            var producersVm = new ListProducersVM()
            {
                Producers = _mapper.Map<List<ProducerVm>>(producers),
                Count = producers.Count()
            };
            return producersVm;
        }

        public ProducerVm GetProducerById(int producerId)
        {
            var producer = _producerRepo.GetProducerById(producerId);
            var producerVm = _mapper.Map<ProducerVm>(producer);
            return producerVm;
        }

        public ProducerVm GetProducerForEdit(int id)
        {
            var producer = _producerRepo.GetProducerById(id);
            var producerVm = _mapper.Map<ProducerVm>(producer);
            return producerVm;
        }

        public void UpdateProducer(ProducerVm producer)
        {
            var producerToUpdate = _mapper.Map<MachiningTechHelperMVC.Domain.Model.Producer>(producer);
            _producerRepo.UpdateProducer(producerToUpdate);
        }
    }
}
