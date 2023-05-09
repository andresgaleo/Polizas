using Application.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PolizasService : IPolizasService
    {
        public IPolizasRepository _polizasRepository;
        public PolizasService(IPolizasRepository polizasRepository)
        {
            _polizasRepository = polizasRepository;
        }
        public PolizasViewModel ObtenerPolizaXPlaca(string placa)
        {
            return new PolizasViewModel()
            {
                Poliza = _polizasRepository.ObtenerPolizaXPlaca(placa)
            };
        }
        public PolizasViewModel ObtenerPolizaXID(int NroPoliza)
        {
            return new PolizasViewModel()
            {
                Poliza = _polizasRepository.ObtenerPolizaXID(NroPoliza)
            };
        }
        public void AgregarPoliza(Polizas ps)
        {
            _polizasRepository.AgregarPoliza(ps);
        }
    }
}
