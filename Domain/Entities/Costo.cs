namespace Domain.Entities
{
    public class Costo
    {
        public int Id { get; set; }
        public string Tramo { get; set; }
        public DateTime Fecha { get; set; }
        public double ResidencialCosto { get; set; }
        public double ComercialCosto { get; set; }
        public double IndustrialCosto { get; set; }
    }

}
