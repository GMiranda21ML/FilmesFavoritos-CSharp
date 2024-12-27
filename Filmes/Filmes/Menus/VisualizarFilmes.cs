using Filmes.Filtros;
using Filmes.Interfaces;
using Filmes.Modelos;
using System.Globalization;

namespace Filmes.Menus;

internal class VisualizarFilmes : Menu, IExibir
{

    private static void Titulo()
    {
        Console.WriteLine(@"
██╗░░░██╗██╗░██████╗██╗░░░██╗░█████╗░██╗░░░░░██╗███████╗░█████╗░██████╗░
██║░░░██║██║██╔════╝██║░░░██║██╔══██╗██║░░░░░██║╚════██║██╔══██╗██╔══██╗
╚██╗░██╔╝██║╚█████╗░██║░░░██║███████║██║░░░░░██║░░███╔═╝███████║██████╔╝
░╚████╔╝░██║░╚═══██╗██║░░░██║██╔══██║██║░░░░░██║██╔══╝░░██╔══██║██╔══██╗
░░╚██╔╝░░██║██████╔╝╚██████╔╝██║░░██║███████╗██║███████╗██║░░██║██║░░██║
░░░╚═╝░░░╚═╝╚═════╝░░╚═════╝░╚═╝░░╚═╝╚══════╝╚═╝╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝

███████╗██╗██╗░░░░░███╗░░░███╗███████╗░██████╗
██╔════╝██║██║░░░░░████╗░████║██╔════╝██╔════╝
█████╗░░██║██║░░░░░██╔████╔██║█████╗░░╚█████╗░
██╔══╝░░██║██║░░░░░██║╚██╔╝██║██╔══╝░░░╚═══██╗
██║░░░░░██║███████╗██║░╚═╝░██║███████╗██████╔╝
╚═╝░░░░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚══════╝╚═════╝░
");
    }

    public void ExibirFiltro(List<Filme> filmes)
    {

        Console.WriteLine("-----------------------------------------------");
        foreach (var filme in filmes)
        {
            filme.ExibirDetalhesDoFilme();
            Console.WriteLine("-----------------------------------------------");

        }
    }


    public static void Menu(List<Filme> filmes)
    {

        Console.Clear();

        Titulo();

        if (filmes.Count() == 0)
        {
            Console.WriteLine("Sua lista de filmes favoritos está vazia, adicione filmes a sua lista!");
            return;
        }


        Console.WriteLine("Seus filmes favoritos: ");

        Console.WriteLine("\nDigite o tipo de visualização você deseja: ");
        Console.WriteLine(@"
Digite 1 para exibir tudo
Digite 2 para filtrar pelo ano de lançamento
Digite 3 para filtrar por genero");
        Console.Write("Digite sua opção: ");
        string opcao = Console.ReadLine()!;

        VisualizarFilmes visualizarFilmes = new();

        if (int.TryParse(opcao, out int op))
        {
            Console.Clear();
            switch (op)
            {
                case 1:
                    visualizarFilmes.ExibirFiltro(filmes);
                    break;

                case 2:


                    Console.WriteLine(@"
Digite 1 para filtrar depois do ano
Digite 2 para filtrar antes do ano
Digite 3 para filtrar durante o ano");
                    
                    try
                    {
                        Console.Write("Digite sua opção: ");
                        int op2 = int.Parse(Console.ReadLine()!);
                        if (op2 >= 4 || op2 <= 0)
                        {
                            Console.WriteLine("Opção invalida! Por favor, digite novamente");
                            break;
                        }

                        Console.Write("Digite o ano do filme: ");
                        int ano = int.Parse(Console.ReadLine()!);

                        Console.Clear();
                        switch (op2)
                        {
                            case 1:
                                LinqFilter.FiltrarDepoisDoAno(filmes, ano);
                                break;

                            case 2:
                                LinqFilter.FiltrarAntesDoAno(filmes, ano);
                                break;

                            case 3:
                                LinqFilter.FiltrarDuranteOAno(filmes, ano);
                                break;

                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ops, houve um erro ({ex.Message})\nPor favor, tente novamente!");
                    }
                    break;

                case 3:
                    Console.Write("Digite o genero (em ingles) do filme: ");
                    string genero = Console.ReadLine()!;
                    genero = ToTitleCase(genero);
                    LinqFilter.FiltrarPorGenero(filmes, genero);
                    break;

                default:
                    Console.WriteLine("Opção invalida! Por favor, digite novamente");
                    break;

            }

        }

    }

}
