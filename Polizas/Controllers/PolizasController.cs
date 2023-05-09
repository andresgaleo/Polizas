using Application.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Polizas.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PolizasController : ControllerBase
    {
        private IPolizasService _polizaService;
        public PolizasController(IPolizasService polizaService)
        {
            _polizaService = polizaService;
        }

        [HttpGet("get/placa/{Placa}")]
        public async Task<IActionResult> ObtenerPolizaPlaca(string Placa) 
        {
            PolizasViewModel pvm = _polizaService.ObtenerPolizaXPlaca(Placa);
            return Ok(pvm);
        }
        [HttpGet("get/poliza/{NroPoliza}")]
        public async Task<IActionResult> ObtenerPolizaNroPoliza(int NroPoliza)
        {
            PolizasViewModel pvm = _polizaService.ObtenerPolizaXID(NroPoliza);
            return Ok(pvm);
        }
        [HttpPost]
        public async Task<IActionResult> AgregarPoliza(Domain.Entities.Polizas ps)
        {
            if (ps.FechaRegistroPoliza < DateTime.Today)
            {
                return BadRequest();
            }
            _polizaService.AgregarPoliza(ps);
            return Ok();
        }
    }
}
