using System;

namespace TrabalhoDistribuicaoBinomial.Classes
{
    public class DistribuicaoBinomial
    {
        #region Atributos Públicos
        public double N { get; set; }
        public double K { get; set; }
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
            this.K = PerguntarValor("k");
            this.P = PerguntarValor("p");
        }

        public void ObterValoresPoisson()
        {
            Console.WriteLine("");
            this.K = PerguntarValor("k");
            this.Lambda = PerguntarValor("Poisson");
        }

        public void ObterValorCalculoPoisson()
        {
            Console.WriteLine("");
            this.N = PerguntarValor("n");
            this.P = PerguntarValor("p");
            this.K = PerguntarValor("k");
        }

        public double CalcularDistribuicaoBinomialIndividual()
        {
            AnaliseCombinatoria analiseCombinatoria = new AnaliseCombinatoria();

            double resultadoAnaliseCombinatoria = analiseCombinatoria.CalcularAnaliseCombinatoria(this.K, this.N);
            return (resultadoAnaliseCombinatoria * (Math.Pow(this.P, this.K) * (Math.Pow((1 - this.P), (this.N - this.K)))));
        }

        public double CalcularDistribuicaoAcumulada()
        {
            AnaliseCombinatoria analise = new AnaliseCombinatoria();

            var euler = Math.E;
            var fatorialK = analise.CalcularFatorial(this.K);
            var eulerElevado = Math.Round(Math.Pow(euler, (this.Lambda * -1)), 9);
            var lambdaElevado = Math.Round(Math.Pow(this.Lambda, this.K), 2);

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
