namespace desafio_rotas.Model
{
    public class Truck
    {
        public List<int> routes { get; set; }
        public int totalRoute { get; set; }
        public Truck()
        {
            this.routes = new();
        }

        public void AddRoute(int route)
        {
            this.routes.Add(route);
            SumRoutes();
        }
        
        private void SumRoutes() => this.totalRoute = this.routes.Sum();


    }
}
