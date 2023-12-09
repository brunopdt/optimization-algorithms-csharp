using desafio_rotas.Model;
using Microsoft.AspNetCore.Mvc;

namespace desafio_rotas.Controllers
{
    [ApiController]
    [Route("routes")]
    public class RoutesController : ControllerBase
    {
        [HttpGet]
        public List<int[]> getRoutes() => DataApplication.baseRoutes;

        [HttpPost("/generate")]
        public List<int[]> generateRoutes(int quantRoutes, int sizeSet,
        double dispersion)
        {
            DataApplication.baseRoutes = ProblemGenerator.generateRoutes(quantRoutes, sizeSet, dispersion);
            return DataApplication.baseRoutes;
        }

    }
}
