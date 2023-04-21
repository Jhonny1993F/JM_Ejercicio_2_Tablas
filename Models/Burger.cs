namespace JM_Ejercicio_2_Tablas.Models
{
    public class Burger
    {
        public int BurgerID { get; set; }
        public string? Name { get; set; }
        public bool WithCheese { get; set; }

        public List<Promo>? Promos { get; set; }


    }
}
