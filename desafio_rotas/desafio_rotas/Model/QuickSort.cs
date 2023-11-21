using System.Diagnostics;

namespace desafio_rotas.Model
{
    public class QuickSort
    {

        #region QuickSort
        static public void sort(int[] vet, int esq, int dir)
        {
            int i, j, x, temp;

            x = vet[(esq + dir) / 2]; // pivo
            i = esq;
            j = dir;
            do
            {
                while (x > vet[i]) i++;
                while (x < vet[j]) j--;
                if (i <= j)
                {
                    temp = vet[i];
                    vet[i] = vet[j];
                    vet[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (esq < j) sort(vet, esq, j);
            if (i < dir) sort(vet, i, dir);
        }
        #endregion

    }
}
