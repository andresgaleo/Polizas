using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Polizas
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int NroPoliza { get; set; }
        public string NombreCliente { get; set; }
        public string IDCliente { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistroPoliza { get; set; }
        public string Coberturas { get; set; }
        public decimal ValorMaximo { get; set; }
        public string NombrePlan { get; set; }
        public string CiudadResidencia { get; set; }
        public string DireccionResidencia { get; set; }
        public string PlacaAutomotor { get; set; } = null;
        public string ModeloAutomotor { get; set; }
        public _tieneInspeccion TieneInspeccion { get; set; }
        public enum _tieneInspeccion
        {
            si,
            no
        }
    }
}
