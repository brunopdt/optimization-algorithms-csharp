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

        public void addRoute(int route)
        {
            this.routes.Add(route);
            sumRoutes();
        }
        
        private void sumRoutes() => this.totalRoute = this.routes.Sum();


    }
}
