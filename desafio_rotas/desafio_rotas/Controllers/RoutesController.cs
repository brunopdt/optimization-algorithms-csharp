using desafio_rotas.Model;
using Microsoft.AspNetCore.Mvc;

namespace desafio_rotas.Controllers
{
    [ApiController]
    [Route("routes")]
    public class RoutesController : ControllerBase
    {
        [HttpGet]
        public int[] getRoutes() => DataApplication.transporter.routes;

        [HttpPost("/generate")]
        public int[] generateRoutes(int quantRoutes, double dispersion) => DataApplication.transporter.generateRoutes(quantRoutes, dispersion);

        [HttpPost]
        public int[] addRoutes([FromBody] int[] routes) => DataApplication.transporter.addRoutes(routes);
    }
}
