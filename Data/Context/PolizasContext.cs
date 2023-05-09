using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class PolizasContext
    {
        public IConfiguration Configuration { get; }
        public readonly IMongoCollection<Polizas> _polizasCollection;
        public PolizasContext(IConfiguration configuration)
        {
            Configuration = configuration;
            var mongoClient = new MongoClient(Configuration.GetSection("PolizasDatabase")["ConnectionString"]);
            var mongoDatabase = mongoClient.GetDatabase(Configuration.GetSection("PolizasDatabase")["DatabaseName"]);
            _polizasCollection = mongoDatabase.GetCollection<Polizas>(
                    Configuration.GetSection("PolizasDatabase")["PolizasCollectionName"]);
        }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string PolizasCollectionName { get; set; }
    }
}
