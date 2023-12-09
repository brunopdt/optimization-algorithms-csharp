using desafio_rotas.Model;
using Microsoft.AspNetCore.Mvc;

namespace desafio_rotas.Controllers
{
    [ApiController]
    [Route("algorithm")]
    public class Algorithm : ControllerBase
    {
        [HttpGet("/divideAndConquer")]
        public void divideAndConquer()
        {
        }
    }
}
