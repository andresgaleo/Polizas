using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPolizasRepository
    {
        public Task<Polizas> ObtenerPolizaXPlaca(string Placa);
        public Task<Polizas> ObtenerPolizaXID(int NroPoliza);
        public void AgregarPoliza(Polizas ps);
    }
}
