namespace desafio_rotas.Model
{
    public class DynamicProgramming(Transporter transporter)
    {
        private Transporter transporter = transporter;
        private ReportResult reportResult = new ReportResult(transporter);
        private List<int> rotasPossiveis = new(); 

        private void cloneRoutes() => transporter.routes.ForEach(route => rotasPossiveis.Add(route));
        private void CalcularResultado(List<int> rotasPossiveis, int[] limitesTabela)
        {
            for (int i = 0; i < transporter.trucks.Count; i++)
            {
                transporter.trucks[i].AddRoute(CalcularRotasParaCadaCaminhao(rotasPossiveis, limitesTabela));
            }
        }
        private List<int> EncontrarRotasSolucao(int[,] tabela, List<int> rotas)
        {
            List<int> rotasSolucao = new List<int>();
            int linha = tabela.GetLength(0) - 1;
            int coluna = tabela.GetLength(1) - 1;


            while (linha >= 0 && coluna > 0)
            {
                if (linha == 0 && rotas[linha] == tabela[linha, coluna])
                {
                    rotasSolucao.Add(rotas[linha]);
                    break;
                }
                else if (linha == 0)
                {
                    break;
                }
                else if (tabela[linha, coluna] != tabela[linha - 1, coluna])
                {
                    rotasSolucao.Add(rotas[linha]);
                    coluna -= rotas[linha];
                    linha -= 1;
                }
                else
                {
                    linha -= 1;
                }
            }

            return rotasSolucao;
        }
        private int[] CalcularLimitesTabela()
        {
            double limiteSuperiorDouble = (transporter.sumRoutes / transporter.trucks.Count) * (1 + transporter.tolerance);
            int limiteSuperior = (int)Math.Floor(limiteSuperiorDouble);
            int[] limitesTabela = new int[limiteSuperior];
            for (int i = 0; i < limiteSuperior; i++)
            {
                limitesTabela[i] = i;
            }
            return limitesTabela;
        }
        private int[] RemoverRotasUtilizadas(List<int> rotasPossiveis, List<int> rotasSolucao)
        {
            foreach (int rota in rotasSolucao)
            {
                int index = rotasPossiveis.FindIndex(r => r == rota);
                if (index != -1)
                {
                    rotasPossiveis.RemoveAt(index);
                }
            }

            // Converte a lista de int para um array de int
            int[] limitesTabela = rotasPossiveis.ToArray();

            return limitesTabela;
        }
        private List<int> CalcularRotasParaCadaCaminhao(List<int> rotasPossiveis, int[] limitesTabela)
        {

            List<int> rotasSolucao;


            int[,] tabela = new int[rotasPossiveis.Count, limitesTabela.Length];

            for (int i = 0; i < rotasPossiveis.Count; i++)
            {
                for (int j = 0; j < limitesTabela.Length; j++)
                {
                    if ((i == 0 && rotasPossiveis[i] > j) || j == 0)
                    {
                        tabela[i, j] = 0;
                    }
                    else if (i == 0 && rotasPossiveis[i] <= j)
                    {
                        tabela[i, j] = rotasPossiveis[i];
                    }
                    else if (rotasPossiveis[i] <= limitesTabela[j])
                    {
                        tabela[i, j] = Math.Max(tabela[i - 1, j], rotasPossiveis[i] + tabela[i - 1, j - rotasPossiveis[i]]);
                    }
                    else
                    {
                        tabela[i, j] = tabela[i - 1, j];
                    }
                }
            }

            rotasSolucao = EncontrarRotasSolucao(tabela, rotasPossiveis);

            RemoverRotasUtilizadas(rotasPossiveis, rotasSolucao);

            return rotasSolucao;
        }

        public ReportResult RunMethod()
        {
            reportResult.startTime();
            int[] limitesTabela = CalcularLimitesTabela();
            cloneRoutes();
            CalcularResultado(rotasPossiveis, limitesTabela);
            reportResult.endTime();
            return this.reportResult;
        }
    }
}
