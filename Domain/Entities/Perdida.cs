namespace Domain.Entities
{
    public class Perdida
    {
        public int Id { get; set; }
        public string Tramo { get; set; }
        public DateTime Fecha { get; set; }
        public double ResidencialPorcentaje { get; set; }
        public double ComercialPorcentaje { get; set; }
        public double IndustrialPorcentaje { get; set; }
    }

}
