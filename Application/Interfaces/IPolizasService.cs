using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPolizasService
    {
        PolizasViewModel ObtenerPolizaXPlaca(string Placa);
        PolizasViewModel ObtenerPolizaXID(int NroPoliza);
        void AgregarPoliza(Polizas ps);
    }
}
