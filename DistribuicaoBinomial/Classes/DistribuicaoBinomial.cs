using System;

namespace TrabalhoDistribuicaoBinomial.Classes
{
    public class DistribuicaoBinomial
    {
        #region Atributos Públicos
        public double N { get; set; }
        public double X { get; set; }
        public double P { get; set; }
        public double Lambda { get; set; }
        #endregion

        #region Atributos Privados
        private Padronizacao padronizacao { get; set; } = new Padronizacao();
        #endregion

        #region Métodos Públicos
        public void ObterValores()
        {
            this.N = PerguntarValor("n");
            this.X = PerguntarValor("x");
            this.P = PerguntarValor("p em valor absoluto");
        }

        public void ObterValoresPoisson()
        {
            Console.WriteLine("");
            this.X = PerguntarValor("x");
            this.Lambda = PerguntarValor("Poisson");
        }

        public void ObterValorCalculoPoisson()
        {
            Console.WriteLine("");
            this.N = PerguntarValor("n");
            this.P = PerguntarValor("p");
            this.X = PerguntarValor("x");
        }

        public double CalcularDistribuicaoBinomialIndividual(double x)
        {
            AnaliseCombinatoria analiseCombinatoria = new AnaliseCombinatoria();

            double resultadoAnaliseCombinatoria = analiseCombinatoria.CalcularAnaliseCombinatoria(x, this.N);
            return (resultadoAnaliseCombinatoria * (Math.Pow(this.P, x) * (Math.Pow((1 - this.P), (this.N - x)))));
        }

        public double CalcularDistribuicaoBinomialAcumulada()
        {
            double total = 0;

            Console.WriteLine("");
            Console.WriteLine("Calculando o x...");
            Console.WriteLine("");

            for (int i = 0; i <= this.X; i++)
            {
                double resultado = Math.Round(CalcularDistribuicaoBinomialIndividual(i), 4);
                Console.WriteLine($"X = {i} = {resultado}");
                total += resultado;
            }

            return total;
        }

        public double CalcularDistribuicaoDePoisson()
        {
            AnaliseCombinatoria analise = new AnaliseCombinatoria();

            var euler = Math.E;
            var fatorialK = analise.CalcularFatorial(this.X);
            var eulerElevado = Math.Round(Math.Pow(euler, (this.Lambda * -1)), 9);
            var lambdaElevado = Math.Round(Math.Pow(this.Lambda, this.X), 2);

            return (eulerElevado * lambdaElevado) / fatorialK;
        }

        public void CalcularValorPoisson()
        {
            this.Lambda = (this.N * this.P);
        }
        #endregion

        #region Métodos Privados
        private double PerguntarValor(string nomeVariavel)
        {
            string entrada = "";
            double valorConvertido = 0;

            do
            {
                Console.Write($"Digite o valor de {nomeVariavel}: ");
                entrada = Console.ReadLine();

                entrada = padronizacao.TratarPontuacaoEntrada(entrada);

                if (!double.TryParse(entrada, out valorConvertido))
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Valor entrada inválido, por favor digite um valor válido para {nomeVariavel}.");
                    Console.WriteLine("");
                }
                else
                    break;
            }
            while (true);

            return valorConvertido;
        }
        #endregion
    }
}
