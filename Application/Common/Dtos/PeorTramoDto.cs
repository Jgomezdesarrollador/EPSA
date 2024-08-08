namespace Application.Common.Dtos
{
    public class PeorTramoDto
    {
        public string Tramo { get; set; }
        public double TotalPerdida { get; set; }
        public DateTime Fecha { get; set; }
        public List<TipoClientePerdidaDto> Perdidas { get; set; }
    }

    public class TipoClientePerdidaDto
    {
        public int Perdida { get; set; }
        public List<ClientePerdidaDto> Valores { get; set; }
    }

    public class ClientePerdidaDto
    {
        public string Cliente { get; set; }
        public double PorcentajePerdida { get; set; }
    }
}
