using Filmes.Menus;
using Filmes.Modelos;
using System.Runtime.Serialization;
using System.Text.Json;

public class Program
{
    public static async Task Main()
    {
        Menu menu = new Menu();

        List<Filme> filmes = new List<Filme>();

        while (true)
        {
            Console.Clear();

            menu.Titulo();
            Console.Write("Digite sua opção: ");
            string opcao = Console.ReadLine()!;

            if (int.TryParse(opcao, out int op))
            {
                switch (op)
                {
                    case 0:
                        Console.WriteLine("Saindo...");
                        return;

                    case 1:
                        await AdicionarFilme.Menu(filmes);
                        break;
                        
                    case 2:
                        VisualizarFilmes.Menu(filmes);
                        break;
                        
                    case 3:
                        DeletarFilme.Menu(filmes);
                        break;

                    default:
                        Console.WriteLine("Opção invalida! Por favor, digite novamente");
                        break;
                                       
                }

            }
            else
            {
                Console.WriteLine("Opção invalida! Por favor, digite novamente");
            }

            menu.LimparTela();

        }

    }

}