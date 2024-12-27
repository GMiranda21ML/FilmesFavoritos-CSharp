using System.Text.Json;

namespace Filmes.Modelos;

internal class APIOmdb
{
    public static async Task<string> ChamarAPI(string filme)
    {
        using(HttpClient client = new HttpClient())
        {
            string url = await client.GetStringAsync($"https://www.omdbapi.com/?t={filme}&apikey=9882acd4");
            return url;
        }
    }

    public static Filme VisualizarAPI(string url)
    {
        var filme = JsonSerializer.Deserialize<Filme>(url);
        return filme;
    }

}
