using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using desafio_rotas.Model;
namespace desafio_rotas.Model
{
    public static class DataApplication
    {
        public static Transporter transporter = new();
        public static List<Report> reports = new();
    }
}
