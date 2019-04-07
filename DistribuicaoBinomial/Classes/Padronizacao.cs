using System.Text.RegularExpressions;

namespace TrabalhoDistribuicaoBinomial.Classes
{
    public class Padronizacao
    {
        #region Métodos Públicos
        public string TratarPontuacaoEntrada(string entrada)
        {
            entrada = entrada.Replace(".", ",");

            var apenasDigitos = new Regex(@"[^\d, \+-]");

            return apenasDigitos.Replace(entrada, "");
        }
        #endregion
    }
}
