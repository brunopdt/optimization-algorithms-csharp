using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using desafio_rotas.Model;
namespace desafio_rotas.Model
{
    public static class DataApplication
    {
        public static List<Report> reports = new();
        public static List<int[]> baseRoutes = ProblemGenerator.generateRoutes(10,2,1);
    }
}
