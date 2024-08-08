using Application.Common.Dtos;
using Infrastructura.Data.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Consumos.Queries
{
    public class GetTopPeoresTramosQuery : IRequest<List<PeorTramoDto>>
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }

    public class GetTopPeoresTramosHandler : IRequestHandler<GetTopPeoresTramosQuery, List<PeorTramoDto>>
    {
        private readonly EpsaDbContext _context;

        public GetTopPeoresTramosHandler(EpsaDbContext context)
        {
            _context = context;
        }

        public async Task<List<PeorTramoDto>> Handle(GetTopPeoresTramosQuery request, CancellationToken cancellationToken)
        {
            var perdidas = await _context.Perdidas
            .Where(p => p.Fecha >= request.FechaInicio && p.Fecha <= request.FechaFin)
            .ToListAsync(cancellationToken);

            var topPerdidas = perdidas
            .Select(p => new
            {
                p.Tramo,
                TotalPerdida = p.ResidencialPorcentaje + p.ComercialPorcentaje + p.IndustrialPorcentaje,
                Fecha = p.Fecha,
                Detalles = new List<ClientePerdidaDto>
                {
                    new ClientePerdidaDto { Cliente = "Residencial", PorcentajePerdida = p.ResidencialPorcentaje },
                    new ClientePerdidaDto { Cliente = "Comercial", PorcentajePerdida = p.ComercialPorcentaje },
                    new ClientePerdidaDto { Cliente = "Industrial", PorcentajePerdida = p.IndustrialPorcentaje }
                }
            })
            .OrderByDescending(p => p.TotalPerdida)
            .Take(20)
            .ToList();

            var result = topPerdidas.Select((t, index) => new PeorTramoDto
            {
                Tramo = t.Tramo,
                TotalPerdida = t.TotalPerdida,
                Fecha = t.Fecha,
                Perdidas = new List<TipoClientePerdidaDto>
            {
                new TipoClientePerdidaDto
                {
                    Perdida = index + 1,
                    Valores = t.Detalles
                }
            }
            }).ToList();


            return result;
        }
    }
}
