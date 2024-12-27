using Filmes.Modelos;

namespace Filmes.Menus;

internal class DeletarFilme : Menu
{
    private static void Titulo()
    {
        Console.WriteLine(@"
██████╗░███████╗██╗░░░░░███████╗████████╗░█████╗░██████╗░  ███████╗██╗██╗░░░░░███╗░░░███╗███████╗
██╔══██╗██╔════╝██║░░░░░██╔════╝╚══██╔══╝██╔══██╗██╔══██╗  ██╔════╝██║██║░░░░░████╗░████║██╔════╝
██║░░██║█████╗░░██║░░░░░█████╗░░░░░██║░░░███████║██████╔╝  █████╗░░██║██║░░░░░██╔████╔██║█████╗░░
██║░░██║██╔══╝░░██║░░░░░██╔══╝░░░░░██║░░░██╔══██║██╔══██╗  ██╔══╝░░██║██║░░░░░██║╚██╔╝██║██╔══╝░░
██████╔╝███████╗███████╗███████╗░░░██║░░░██║░░██║██║░░██║  ██║░░░░░██║███████╗██║░╚═╝░██║███████╗
╚═════╝░╚══════╝╚══════╝╚══════╝░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝  ╚═╝░░░░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚══════╝
");
    }

    public static void Menu(List<Filme> filmes)
    {
        Console.Clear();

        Titulo();

        if (filmes.Count() == 0)
        {
            Console.WriteLine("Sua lista de filmes favoritos está vazia, adicione filmes a sua lista!");
            return;
        };
        

        Console.Write("Digite o nome do filme que você deseja deletar: ");
        string nome = Console.ReadLine()!;
        nome = ToTitleCase(nome);

        bool validacao = false;
        for (int i = filmes.Count - 1; i >= 0; i--)
        {
            if (filmes[i].Titulo.Equals(nome))
            {
                validacao = true;
                filmes.RemoveAt(i);
                Console.WriteLine($"O filme {nome} foi deletado com sucesso!");
                break;
            }
        }

        if (!validacao)
        {
            Console.WriteLine($"O filme {nome} não existe na sua lista!");
        }
    }
}
