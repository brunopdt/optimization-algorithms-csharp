using System.Linq;

namespace desafio_rotas.Model
{

    public class DivisionConquest
    {
        Transporter tranporter;
        public DivisionConquest(Transporter tranporter) {
            this.tranporter = tranporter; 
        }
        private void algoritmo(int[] routes, List<int> solucao)
        {
            if(routes.Length == 2)
            {
                int result = this.validate(routes, solucao);
                if(result != 0)
                {
                    solucao.Add(result);
                }
                return;
            }

            int halfRoutes = Convert.ToInt32(Math.DivRem(routes.Length, 2));

            algoritmo(routes.Take(halfRoutes).ToArray(), solucao);
            algoritmo(routes.Skip(halfRoutes).ToArray(), solucao);
        }

        private int validate(int[] routes, List<int> solucao)
        {
            int total = solucao.Sum();
            double average = tranporter.averageRoutes * 1.1;
            if (total + routes[routes.Length - 1] <= average)
                return routes[routes.Length - 1];
            else if (total + routes[0] <= average)
                return routes[0];
            else
                return 0;
        }
       public List<int> divisaoConquista()
        {
            List<int> solucao = new List<int>();
            algoritmo(this.tranporter.routes, solucao);

            return solucao;
        }
    }
}
