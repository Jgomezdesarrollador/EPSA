namespace Application.Common.Dtos
{
    public class HistoricoConsumoDto
    {
        public string Tramo { get; set; }
        public List<TramoHistoricoDto> TipoCliente { get; set; }
    }

    public class TramoHistoricoDto
    {
        public string Cliente { get; set; }
        public List<HistoricoDto> Historico { get; set; }
    }
}
