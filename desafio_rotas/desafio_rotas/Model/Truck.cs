namespace desafio_rotas.Model
{
    public class Truck
    {
        public List<int> routes { get; set; }
        public int totalRoute { get; set; }
        public Truck()
        {
            this.routes = new();
            this.totalRoute = 0;
        }

        public void AddRoute(int route)
        {
            this.routes.Add(route);
            SumRoutes();
        }
        public void AddRoute(List<int> routes)
        {
            this.routes = routes;
            SumRoutes();
        }

        public void RemoveRoute(int route)
        {
            this.routes.Remove(route);
            SumRoutes();
        }

        private void SumRoutes() => this.totalRoute = this.routes.Sum();


    }
}
