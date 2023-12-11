using desafio_rotas.DTOs;
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
        public List<int[]> generateRoutes([FromBody] GenerateRoutesDTO dto)
        {
            DataApplication.baseRoutes = ProblemGenerator.generateRoutes(dto.quantRoutes, dto.sizeSet, dto.dispersion);
            return DataApplication.baseRoutes;
        }

    }
}
