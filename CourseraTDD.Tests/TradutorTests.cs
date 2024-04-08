using CourseraTDD.Tests.Entities;
using CourseraTDD.Tests.Validation;

namespace CourseraTDD.Tests;

public class TradutorTests
{
    private Tradutor _tradutor;
    public TradutorTests()
    {
        _tradutor = new();
    }

    [Fact]
    public void DeveAdicionarUmaTraducao()
    {
        _tradutor.AdicionaTraducao(palavra: "bom", traducao: "good");

        Assert.Equal("good", _tradutor.Traduzir("bom"));
    }

    [Fact]
    public void DeveTraduzirUmaPalavra()
    {
        _tradutor.AdicionaTraducao(palavra: "bom", traducao: "good");

        var pTraduzida = _tradutor.Traduzir(palavra: "bom");

        Assert.Equal("good", pTraduzida);
    }

    [Fact]
    public void DeveTraduzirDuasPalavra()
    {
        _tradutor.AdicionaTraducao(palavra: "bom", traducao: "good");
        _tradutor.AdicionaTraducao(palavra: "mal", traducao: "bad");

        var traducaoBom = _tradutor.Traduzir(palavra: "bom");
        var traducaoMal = _tradutor.Traduzir(palavra: "mal");

        Assert.Equal("good", traducaoBom);
        Assert.Equal("bad", traducaoMal);
    }

    [Fact]
    public void DeveTraduzirUmaPalavraComDoisSignificados()
    {
        _tradutor.AdicionaTraducao(palavra: "bom", traducao: "good");
        _tradutor.AdicionaTraducao(palavra: "bom", traducao: "nice");

        var pTraduzida = _tradutor.Traduzir(palavra: "bom");

        Assert.Equal("good,nice", pTraduzida);
    }

    [Fact]
    public void DeveTraduzirUmaFrase()
    {
        string frase = "Guerra é ruim";
        _tradutor.AdicionaTraducao("Guerra", "War");
        _tradutor.AdicionaTraducao("é", "is");
        _tradutor.AdicionaTraducao("ruim", "bad");

        string fraseTraduzida = _tradutor.TraduzirFrase(frase: frase);

        Assert.Equal("War is bad", fraseTraduzida);
    }

    [Fact]
    public void DeveTraduzirUmaFraseComDuasTraducoesMesmaPalavra()
    {
        string frase = "paz é bom";

        _tradutor.AdicionaTraducao("paz", "peace");
        _tradutor.AdicionaTraducao("é", "is");
        _tradutor.AdicionaTraducao(palavra: "bom", traducao: "good");
        _tradutor.AdicionaTraducao(palavra: "bom", traducao: "nice");

        string fraseTraduzida = _tradutor.TraduzirFrase(frase: frase);

        Assert.Equal("peace is good", fraseTraduzida);
    }

    [Fact]
    public void DeveRetornarExcecaoPalavraNaoExiste()
    {
        try
        {
            _tradutor.Traduzir("existe");
        }
        catch (TradutorException e)
        {
            Assert.Equal("Palavra não existe tradução", e.Message);
        }

    }
}