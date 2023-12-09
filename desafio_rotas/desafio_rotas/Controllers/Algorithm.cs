using desafio_rotas.Model;
using Microsoft.AspNetCore.Mvc;

namespace desafio_rotas.Controllers
{
    [ApiController]
    [Route("algorithm")]
    public class Algorithm : ControllerBase
    {
        [HttpGet]
        public List<Truck> divisionConquest()
        {
            Transporter tranporter = new Transporter(3, [ 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 ]);
            DivisionConquest division = new(tranporter);
            division.divisaoConquista();
            return tranporter.listTruck;

        }
    }
}
