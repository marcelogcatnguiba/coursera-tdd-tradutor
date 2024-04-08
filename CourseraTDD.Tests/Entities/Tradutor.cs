using CourseraTDD.Tests.Validation;

namespace CourseraTDD.Tests.Entities
{
    public class Tradutor
    {
        private Dictionary<string, string> _dicTraducoes = new Dictionary<string, string>();
        internal string Traduzir(string palavra)
        {
            TradutorException
                .Quando(_dicTraducoes.NotContainsKey(palavra), "Palavra não existe tradução");

            return _dicTraducoes[palavra];
        }

        internal void AdicionaTraducao(string palavra, string traducao)
        {
            if (_dicTraducoes.ContainsKey(palavra))
            {
                _dicTraducoes[palavra] += ',' + traducao;

            }
            else
            {
                _dicTraducoes.Add(palavra, traducao);
            }

        }

        internal string TraduzirFrase(string frase)
        {
            var fraseTraduzida = "";
            var palavraDaFrase = frase.Split(" ");

            for (int i = 0; i < palavraDaFrase.Length; i++)
            {
                var traducao = Traduzir(palavraDaFrase[i]);
                fraseTraduzida += PrimeiraTraducao(temVariasTraducoes: traducao.Contains(','), traducao) + " ";
            }

            return fraseTraduzida.Trim();
        }

        private string PrimeiraTraducao(bool temVariasTraducoes, string traducao)
        {
            if (temVariasTraducoes)
                return traducao[..traducao.IndexOf(',')];
            return traducao;
        }
    }
}