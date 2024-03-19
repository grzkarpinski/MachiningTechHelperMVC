using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.Producer
{
    public class ListProducersVM
    {
        public List<ProducerVm> Producers { get; set; }
        public int Count { get; set; }
    }
}
