using desafio_rotas.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace desafio_rotas.Controllers
{
    [ApiController]
    [Route("transporter")]
    public class TransporterController : ControllerBase
    {
        [HttpGet]
        public Transporter GetTransporter() => DataApplication.transporter;
    }
}
