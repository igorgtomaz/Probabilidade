﻿using System;

namespace TrabalhoDistribuicaoBinomial.Classes
{
    public class Menu
    {
        #region Atributos Públicos
        public int Opcao { get; set; }
        #endregion

        #region Atributos Privados
        private Padronizacao padronizacao { get; set; } = new Padronizacao();
        #endregion

        #region Métodos Públicos
        public void ExibirMenu()
        {
            ExibirInicioMenu();
            do
            {
                ExibirMeioMenu();
                this.Opcao = ObterRespostaMenu();
                EscolherMenu(this.Opcao);
                Console.Clear();
            } while (this.Opcao != 3);
        }
        #endregion

        #region Métodos Privados
        private int ObterRespostaMenu()
        {
            DistribuicaoBinomial distribuicaoBinomial = new DistribuicaoBinomial();
            var resposta = Console.ReadLine();
            int valorConvertido = 0;

            resposta = padronizacao.TratarPontuacaoEntrada(resposta);

            if (int.TryParse(resposta, out valorConvertido))
                return valorConvertido;

            return -1;
        }

        private void ExibirInicioMenu()
        {
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Bem vindo!");
            Console.WriteLine("");
        }

        private void ExibirMeioMenu()
        {
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Calcular Distribuição Binomial Individual");
            Console.WriteLine("2 - Calcular Distribuição Binomial Acumulada");
            Console.WriteLine("3 - Sair");
            Console.Write("Resposta: ");
        }

        private void ApresentarFinalCalculo(double resultado)
        {
            Console.WriteLine("");
            Console.WriteLine($"Resultado = {resultado}");
            Console.WriteLine("");
            Console.WriteLine("Opção concluída, aperte qualquer tecla para continuar...");
            Console.WriteLine("");
            Console.ReadKey();
        }

        private void ApresentarFinalPrograma()
        {
            Console.WriteLine("");
            Console.WriteLine("Programa encerrado.");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.WriteLine("");
            Console.ReadKey();
        }

        private void EscolherMenu(int opcao)
        {
            DistribuicaoBinomial distribuicaoBinomial = new DistribuicaoBinomial();

            if (opcao == 1)
            {
                Console.Clear();
                distribuicaoBinomial.ObterValores();
                var resultado = Math.Round(distribuicaoBinomial.CalcularDistribuicaoBinomialIndividual(distribuicaoBinomial.X), 4);

                ApresentarFinalCalculo(resultado);
            }
            else if (opcao == 2)
            {
                Console.Clear();
                distribuicaoBinomial.ObterValores();
                var resultadoFinal = distribuicaoBinomial.CalcularDistribuicaoBinomialAcumulada();

                ApresentarFinalCalculo(resultadoFinal);
            }
            else if (opcao == 3)
            {
                ApresentarFinalPrograma();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Entrada inválida, favor digitar um valor valido (1 - 3)");
                Console.WriteLine("Aperte qualquer tecla para continuar...");
                Console.ReadLine();
            }
        }
        #endregion
    }
}
