using CourseraTDD.Tests.Validation;

namespace CourseraTDD.Tests.Entities
{
    public class Tradutor
    {
        private Dictionary<string, string> _dicTraducoes = new Dictionary<string, string>();
        internal string Traduzir(string palavra)
        {
            TradutorException
                .Quando(_dicTraducoes.ContainsKey(palavra) is false, "Palavra não existe tradução");

            return _dicTraducoes[palavra];
        }

        internal bool AdicionaTraducao(string palavra, string traducao)
        {
            try
            {
                if (_dicTraducoes.ContainsKey(palavra))
                    _dicTraducoes[palavra] += ',' + traducao;

                _dicTraducoes.Add(palavra, traducao);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal string TraduzirFrase(string frase)
        {
            var fraseTraduzida = "";
            var palavrasFrase = frase.Split(" ");

            for (int i = 0; i < palavrasFrase.Length; i++)
            {
                var traducao = Traduzir(palavrasFrase[i]);
                if (traducao.Contains(','))
                    fraseTraduzida += PrimeiraTraducao(traducao);
                else
                    fraseTraduzida += traducao + " ";
            }

            return fraseTraduzida.Trim();
        }

        private string PrimeiraTraducao(string traducao)
        {
            return traducao[..traducao.IndexOf(',')];
        }
    }
}