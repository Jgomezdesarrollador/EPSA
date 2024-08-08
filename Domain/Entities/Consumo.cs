namespace Domain.Entities
{
    public class Consumo
    {
        public int Id { get; set; }
        public string Tramo { get; set; }
        public DateTime Fecha { get; set; }
        public int ResidencialWh { get; set; }
        public int ComercialWh { get; set; }
        public int IndustrialWh { get; set; }
    }

}
