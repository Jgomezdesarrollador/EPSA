namespace Application.Common.Dtos
{
    public class HistoricoConsumoClienteDto
    {
        public string Cliente { get; set; }
        public List<TipoClienteHistoricoDto> Tramos { get; set; }
    }

    public class TipoClienteHistoricoDto
    {
        public string Tramo { get; set; }
        public List<HistoricoDto> Historico { get; set; }
    }
}
