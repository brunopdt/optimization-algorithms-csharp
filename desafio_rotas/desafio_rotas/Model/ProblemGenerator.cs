namespace desafio_rotas.Model
{
    public class ProblemGenerator
    {
        static Random random = new(42);
        static int SIZE_BASE = 13;
        public static int[] generateRoutes(int quantRoutes, double dispersion)
        {
            int tam_max = (int)Math.Ceiling(SIZE_BASE * (1 + dispersion));

            int[] rotas = new int[quantRoutes];
            for (int j = 0; j < quantRoutes; j++)
            {
                rotas[j] = random.Next(SIZE_BASE, tam_max);
            }

            return rotas;
        }
    }
}
