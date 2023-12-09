using desafio_rotas.Model;
using Microsoft.AspNetCore.Mvc;

namespace desafio_rotas.Controllers
{
    [ApiController]
    [Route("algorithm")]
    public class Algorithm : ControllerBase
    {
        [HttpGet]
        public void divisionConquest()
        {
            Transporter tranporter = new Transporter(3, [ 35, 34, 33, 23, 21, 32, 35, 19, 26, 42 ]);
            DivisionConquest division = new(tranporter);
            division.divisaoConquista();

        }
    }
}
