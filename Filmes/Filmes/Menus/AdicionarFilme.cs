using Filmes.Modelos;

namespace Filmes.Menus;

internal class AdicionarFilme : Menu
{

    private static void Titulo()
    {
        Console.WriteLine(@"
░█████╗░██████╗░██╗░█████╗░██╗░█████╗░███╗░░██╗░█████╗░██████╗░  ███████╗██╗██╗░░░░░███╗░░░███╗███████╗
██╔══██╗██╔══██╗██║██╔══██╗██║██╔══██╗████╗░██║██╔══██╗██╔══██╗  ██╔════╝██║██║░░░░░████╗░████║██╔════╝
███████║██║░░██║██║██║░░╚═╝██║██║░░██║██╔██╗██║███████║██████╔╝  █████╗░░██║██║░░░░░██╔████╔██║█████╗░░
██╔══██║██║░░██║██║██║░░██╗██║██║░░██║██║╚████║██╔══██║██╔══██╗  ██╔══╝░░██║██║░░░░░██║╚██╔╝██║██╔══╝░░
██║░░██║██████╔╝██║╚█████╔╝██║╚█████╔╝██║░╚███║██║░░██║██║░░██║  ██║░░░░░██║███████╗██║░╚═╝░██║███████╗
╚═╝░░╚═╝╚═════╝░╚═╝░╚════╝░╚═╝░╚════╝░╚═╝░░╚══╝╚═╝░░╚═╝╚═╝░░╚═╝  ╚═╝░░░░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚══════╝
");
    }


    public static async Task Menu(List<Filme> filmes)
    {
        Console.Clear();
        Titulo();
        Console.Write("Digite o nome do filme que você deseja adicionar a sua lista de favoritos: ");

        string nomeDoFilme = ToTitleCase(Console.ReadLine()!);

        try
        {
            string nomeDoFilmeFormatado = nomeDoFilme.Replace(" ", "+");
            string url = await APIOmdb.ChamarAPI(nomeDoFilmeFormatado);

            var filme = APIOmdb.VisualizarAPI(url);

            filme.ExibirDetalhesDoFilme();

            Console.WriteLine("Este é o filme que você queria?");

            Console.Write("Se esse for o filme, digite (s ou sim), senao digite qualquer tecla: ");
            string escolha = Console.ReadLine()!.ToLower();

            if (escolha.Equals("s") || escolha.Equals("sim"))
            {
                filmes.Add(filme);

                Console.WriteLine($"\nO filme ({nomeDoFilme}) foi adicionado a sua lista de favoritos!\n");

            }
            else
            {
                Console.WriteLine("OK!");
            }

        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"Desculpe não foi possivel achar o filme --> {nomeDoFilme}! Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Thread.Sleep(1000);
    }
}
