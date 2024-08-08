using Application.Common.Dtos;
using Infrastructura.Data.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Consumos.Queries
{
    public class GetHistoricoConsumosPorClienteQuery : IRequest<List<HistoricoConsumoClienteDto>>
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }

    public class GetHistoricoConsumosPorClienteHandler : IRequestHandler<GetHistoricoConsumosPorClienteQuery, List<HistoricoConsumoClienteDto>>
    {
        private readonly EpsaDbContext _context;

        public GetHistoricoConsumosPorClienteHandler(EpsaDbContext context)
        {
            _context = context;
        }
        public async Task<List<HistoricoConsumoClienteDto>> Handle(GetHistoricoConsumosPorClienteQuery request, CancellationToken cancellationToken)
        {
            var consumos = await _context.Consumos
            .Where(c => c.Fecha >= request.FechaInicio && c.Fecha <= request.FechaFin)
            .ToListAsync(cancellationToken);

            var costos = await _context.Costos
                .Where(c => c.Fecha >= request.FechaInicio && c.Fecha <= request.FechaFin)
                .ToListAsync(cancellationToken);

            var perdidas = await _context.Perdidas
                .Where(p => p.Fecha >= request.FechaInicio && p.Fecha <= request.FechaFin)
                .ToListAsync(cancellationToken);

            var result = new List<HistoricoConsumoClienteDto>
            {
                new HistoricoConsumoClienteDto
                {
                    Cliente = "Residencial",
                    Tramos = consumos.GroupBy(c => c.Tramo).Select(g => new TipoClienteHistoricoDto
                    {
                        Tramo = g.Key,
                        Historico = g.Select(c => new HistoricoDto
                        {
                            ConsumoWh = c.ResidencialWh,
                            Costo = costos.FirstOrDefault(k => k.Tramo == c.Tramo && k.Fecha == c.Fecha)?.ResidencialCosto ?? 0,
                            PorcentajePerdida = perdidas.FirstOrDefault(p => p.Tramo == c.Tramo && p.Fecha == c.Fecha)?.ResidencialPorcentaje ?? 0,
                            Fecha = c.Fecha
                        }).ToList()
                    }).ToList()
                },
                new HistoricoConsumoClienteDto
                {
                    Cliente = "Comercial",
                    Tramos = consumos.GroupBy(c => c.Tramo).Select(g => new TipoClienteHistoricoDto
                    {
                        Tramo = g.Key,
                        Historico = g.Select(c => new HistoricoDto
                        {
                            ConsumoWh = c.ComercialWh,
                            Costo = costos.FirstOrDefault(k => k.Tramo == c.Tramo && k.Fecha == c.Fecha)?.ComercialCosto ?? 0,
                            PorcentajePerdida = perdidas.FirstOrDefault(p => p.Tramo == c.Tramo && p.Fecha == c.Fecha)?.ComercialPorcentaje ?? 0,
                            Fecha = c.Fecha
                        }).ToList()
                    }).ToList()
                },
                new HistoricoConsumoClienteDto
                {
                    Cliente = "Industrial",
                    Tramos = consumos.GroupBy(c => c.Tramo).Select(g => new TipoClienteHistoricoDto
                    {
                        Tramo = g.Key,
                        Historico = g.Select(c => new HistoricoDto
                        {
                            ConsumoWh = c.IndustrialWh,
                            Costo = costos.FirstOrDefault(k => k.Tramo == c.Tramo && k.Fecha == c.Fecha)?.IndustrialCosto ?? 0,
                            PorcentajePerdida = perdidas.FirstOrDefault(p => p.Tramo == c.Tramo && p.Fecha == c.Fecha)?.IndustrialPorcentaje ?? 0,
                            Fecha = c.Fecha
                        }).ToList()
                    }).ToList()
                }
            };

            return result;
        }
    }
}
