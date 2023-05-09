using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PolizaRepository : IPolizasRepository
    {
        public PolizasContext _context;
        public PolizaRepository(PolizasContext context)
        {
            _context = context;
        }

        public Task<Polizas> ObtenerPolizaXPlaca(string Placa)
        {
            return _context._polizasCollection.Find(m => m.PlacaAutomotor == Placa).FirstOrDefaultAsync();           
        }
        public Task<Polizas> ObtenerPolizaXID(int NroPoliza)
        {
            return _context._polizasCollection.Find(m=>m.NroPoliza==NroPoliza).FirstOrDefaultAsync();
        }
        public void AgregarPoliza(Polizas ps)
        {
            _context._polizasCollection.InsertOne(ps);
        }
    }
}
