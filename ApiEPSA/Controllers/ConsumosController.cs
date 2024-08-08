using Application.Consumos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEPSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsumosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("historico-tramos")]
        public async Task<IActionResult> GetHistoricoConsumosPorTramos([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            var query = new GetHistoricoConsumosPorTramosQuery { FechaInicio = fechaInicio, FechaFin = fechaFin };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("historico-clientes")]
        public async Task<IActionResult> GetHistoricoConsumosPorCliente([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            var query = new GetHistoricoConsumosPorClienteQuery { FechaInicio = fechaInicio, FechaFin = fechaFin };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("top-peores-tramos")]
        public async Task<IActionResult> GetTopPeoresTramos([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            var query = new GetTopPeoresTramosQuery { FechaInicio = fechaInicio, FechaFin = fechaFin };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
