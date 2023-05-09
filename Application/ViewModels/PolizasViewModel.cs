using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.ViewModels
{
    public class PolizasViewModel
    {
        public Task<IEnumerable<Polizas>> Polizas { get; set; }
        public Task<Polizas> Poliza { get; set; }
        public bool Result { get; set; }
    }
}
