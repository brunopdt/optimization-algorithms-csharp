using desafio_rotas.DTOs;
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

        [HttpPost("/greedy")]
        public List<ReportResult> Greedy([FromBody] GreedyAlgorithmDTO dto)
        {
            Transporter transporter;
            Greedy greedy;
            ReportResult currentReportResult;
            Report report = new("Algoritmo Guloso", "", "Escolhe a melhor opção no momento da iteração, entretanto, não garante o resultado ótimo");

            DataApplication.baseRoutes.ForEach(route =>
            {
                transporter = new(dto.truckAmount, route.ToList());
                greedy = new Greedy(transporter);
                if (dto.method == 1)
                    currentReportResult =  greedy.DistributeRoutes1stAlgorithm();
                else
                    currentReportResult = greedy.DistributeRoutes2ndAlgorithm();

                report.addResult(currentReportResult);
            });
            DataApplication.reports.Add(report);

            return report.results;
        }

        [HttpPost("/dynamicprogramming")]
        public List<ReportResult> DynamicProgramming([FromBody] DynamicProgrammingDTO dto)
        {
            Transporter transporter;
            DynamicProgramming dynamicProgramming;
            ReportResult currentReportResult;
            Report report = new("Algoritmo Programação dinamica", "", "Escolhe a melhor opção no momento da iteração, entretanto, não garante o resultado ótimo");

            DataApplication.baseRoutes.ForEach(route =>
            {
                transporter = new(dto.truckAmount, route.ToList());
                dynamicProgramming = new(transporter);
                currentReportResult = dynamicProgramming.RunMethod();
                report.addResult(currentReportResult);
            });
            DataApplication.reports.Add(report);

            return report.results;
        }
    }
}
