using desafio_rotas.Model;
using Microsoft.AspNetCore.Mvc;

namespace desafio_rotas.Controllers
{
    [ApiController]
    [Route("truck")]
    public class TruckController : ControllerBase
    {
        [HttpGet]
        public List<Truck> getTrucks() => DataApplication.transporter.getTrucks();

        [HttpPost]
        public List<Truck> addTruck(int quantity) => DataApplication.transporter.addTruck(quantity);

    }
}
