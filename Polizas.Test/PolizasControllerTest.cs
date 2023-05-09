using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using FluentAssertions;

namespace Polizas.Test
{
    public class PolizasControllerTest : TestBuider
    {
        [Fact]
        public void CrearPolizaExito()
        {
            int nroPoliza = 124731211;
            string Placa = "DGS576";
            string IDCliente = "1020479511";
            string token = GenerateToken(IDCliente);
            this.Test.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var poliza = new
            {
                NroPoliza = nroPoliza,
                NombreCliente = "Hernán Galeano",
                IDCliente = IDCliente,
                FechaNacimiento = "1997-05-02",
                FechaRegistroPoliza = DateTime.Today,
                Coberturas = "Todo",
                ValorMaximo = 1300000,
                NombrePlan = "GOLD",
                CiudadResidencia = "Medellín",
                DireccionResidencia = "cll 63 # 59a 57",
                PlacaAutomotor = Placa,
                ModeloAutomotor = "2015",
                TieneInspeccion=0
            };

            var carga = this.Test.PostAsync("api/Polizas", poliza, new JsonMediaTypeFormatter()).Result;
            carga.EnsureSuccessStatusCode();
            Assert.True(true, "Registro Guardado Correctamente.");
        }
        [Fact]
        public void CrearPolizaError()
        {
            HttpResponseMessage carga = null;
            int nroPoliza = 124731211;
            string Placa = "DGS576";
            string IDCliente = "1020479511";
            try
            {
                string token = GenerateToken(IDCliente);
                this.Test.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var poliza = new
                {
                    NroPoliza = nroPoliza,
                    NombreCliente = "Hernán Galeano",
                    IDCliente = IDCliente,
                    FechaNacimiento = "1997-05-02",
                    FechaRegistroPoliza = "2023-04-01",
                    Coberturas = "Todo",
                    ValorMaximo = 1300000,
                    NombrePlan = "GOLD",
                    CiudadResidencia = "Medellín",
                    DireccionResidencia = "cll 63 # 59a 57",
                    PlacaAutomotor = Placa,
                    ModeloAutomotor = "2015",
                    TieneInspeccion = 0
                };

                carga = this.Test.PostAsync("api/Polizas", poliza, new JsonMediaTypeFormatter()).Result;
                carga.EnsureSuccessStatusCode();
                Assert.True(false, "Poliza no vigente");
            }
            catch (Exception)
            {
                carga.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }
        [Fact]
        public void ConsultarPolizaxPlacaExito()
        {
            HttpResponseMessage respuesta = null;
            string token = GenerateToken("1020479511");
            this.Test.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var Placa = "DGS575";
            respuesta = this.Test.GetAsync($"api/Polizas/get/placa/{Placa}").Result;
            respuesta.EnsureSuccessStatusCode();
            Assert.True(true, "OK");
        }
        [Fact]
        public void ConsultaPolizaXNroPolizaExito()
        {
            string token = GenerateToken("1020479511");
            this.Test.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage respuesta = null;
            var NroPoliza = 1020479511;
            respuesta = this.Test.GetAsync($"api/Polizas/get/poliza/{NroPoliza}").Result;
            respuesta.EnsureSuccessStatusCode();
            Assert.True(true, "OK");
        }

        public string GenerateToken(string IDCliente)
        {
            HttpResponseMessage respuesta = null;
            respuesta = this.Test.GetAsync($"api/Token/{IDCliente}").Result;
            respuesta.EnsureSuccessStatusCode();
            var token = respuesta.Content.ReadAsStringAsync().Result;
            return token;
        }
    }
}
