using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections;
namespace desafio_rotas.Model
{
    public class Transporter
    {
        public static double tolerance { get; } = 0.1;
        public int[] routes { get; set; }
        public List<Truck> listTruck { get; set; }
        public Transporter() { 
            this.listTruck = new List<Truck>();
            this.routes = ProblemGenerator.generateRoutes(10, 1);
        }


        public List<Truck> addTruck(int quantity) {
            this.listTruck = new List<Truck>();
            for (int i=0; i< quantity; i++)
            {
                this.listTruck.Add(new Truck());
            }
            return this.listTruck;
        }
        public Truck getTruck(int key) => this.listTruck[key];
        public int[] generateRoutes(int quantRoutes, double dispersion)
        {
            this.routes = ProblemGenerator.generateRoutes(quantRoutes, dispersion);
            return this.routes;
        }
        public int[] addRoutes(int[] routes)
        {
            this.routes = routes;
            return this.routes;
        }
        public List<Truck> getTrucks() => this.listTruck;
        public double getAverageRoutes() => this.routes.Average();
    }
}
