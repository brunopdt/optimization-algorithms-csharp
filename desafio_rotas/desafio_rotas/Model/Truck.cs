namespace desafio_rotas.Model
{
    public class Truck
    {
        public int[] routes { get; set; }
        public Truck()
        {
            this.routes = new int[0];
        }

        public void addRoutes(int[] routes)
        {
            this.routes = routes;
        }
    }
}
