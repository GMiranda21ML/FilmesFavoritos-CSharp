using System.Text.Json.Serialization;

namespace Filmes.Modelos;

internal class Filme
{
    [JsonPropertyName("Title")]
    public string? Titulo { get; set; }
    [JsonPropertyName("Year")]
    public string? Ano { get; set; }
    [JsonPropertyName("Runtime")]
    public string? TempoEmMin { get; set; }
    [JsonPropertyName("Genre")]
    public string? Genero { get; set; }
    [JsonPropertyName("Actors")]
    public string? Elenco { get; set; }
    [JsonPropertyName("Director")]
    public string? Diretor { get; set; }

    public string UnicoGenero
    {
        get
        {
            string genero = Genero;

            return genero.Split(",").First();
        }
    }

    public int AnoInteiro
    {
        get
        {
            string anoStr = Ano;
            if (int.TryParse(anoStr, out int ano))
            {
                return ano;
            }
            else
            {
                return 0;
            }

        }
    }

    public void ExibirDetalhesDoFilme()
    {
        Console.WriteLine(@$"
Nome: {Titulo}
Ano de lançamento: {AnoInteiro}
Duração em minutos: {TempoEmMin}
Genero: {UnicoGenero}
Elenco: {Elenco}
Diretor: {Diretor}
");
    }

}
