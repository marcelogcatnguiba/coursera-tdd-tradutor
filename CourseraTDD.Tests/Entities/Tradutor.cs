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