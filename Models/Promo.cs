namespace JM_Ejercicio_2_Tablas.Models
{
    public class Promo
    {
        public int PromoId { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public int BurgerId { get; set; }
        public Burger? Burger { get; set; }

    }
}
