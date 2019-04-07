namespace TrabalhoDistribuicaoBinomial.Classes
{
    public class AnaliseCombinatoria
    {

        #region Métodos Públicos
        public double CalcularAnaliseCombinatoria(double k, double n)
        {
            return (CalcularFatorial(n) / (CalcularFatorial(k) * CalcularFatorial((n - k))));
        }

        public double CalcularFatorial(double valor)
        {
            double total = 1;
            int i;

            for (i = 1; i <= valor; i++, total *= 1)
                total *= i;

            return total;
        }
        #endregion
    }
}
