using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections;
namespace desafio_rotas.Model
{
    public class Transporter
    {
        public double tolerance { get; } = 0.1;
        public double averageTruckRoutes { get; set; }
        public int sumRoutes { get; set; }
        public List<int> routes { get; set; }
        public List<Truck> trucks { get; set; }
        public Transporter(int quantityTrucks, List<int> routes) { 
            this.trucks = new List<Truck>();
            addTruck(quantityTrucks);
            addRoutes(routes);
        }
        private List<Truck> addTruck(int quantity) {
            this.trucks = new List<Truck>();
            for (int i=0; i< quantity; i++)
            {
                this.trucks.Add(new Truck());
            }
            return this.trucks;
        }
        public List<int> addRoutes(List<int> routes)
        {
           
            this.routes = routes;
            this.averageTruckRoutes = this.getAverageTruckRoutes();
            this.sumRoutes = this.getSumRoutes();
            return this.routes;
        }
        private double getAverageTruckRoutes() => Math.Ceiling(Convert.ToDouble(this.routes.Sum() / this.trucks.Count) );
        private int getSumRoutes() => this.routes.Sum();
    }
}
