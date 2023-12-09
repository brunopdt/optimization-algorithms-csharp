using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections;
namespace desafio_rotas.Model
{
    public class Transporter
    {
        public static double tolerance { get; } = 0.1;
        public double averageTruckRoutes { get; set; }
        public int sumRoutes { get; set; }
        public List<int> routes { get; set; }
        public List<Truck> listTruck { get; set; }
        public Transporter(int quantityTrucks, int[] routes) { 
            this.listTruck = new List<Truck>();
            addRoutes(routes);
            addTruck(quantityTrucks);
        }
        private List<Truck> addTruck(int quantity) {
            this.listTruck = new List<Truck>();
            for (int i=0; i< quantity; i++)
            {
                this.listTruck.Add(new Truck());
            }
            return this.listTruck;
        }
        public List<int> addRoutes(List<int> routes)
        {
           
            this.routes = routes;
            this.averageTruckRoutes = this.getAverageTruckRoutes();
            this.sumRoutes = this.getSumRoutes();
            return this.routes;
        }
        private double getAverageTruckRoutes() => Math.Ceiling(Convert.ToDouble(this.routes.Sum() / this.listTruck.Count) );
        private int getSumRoutes() => this.routes.Sum();
    }
}
