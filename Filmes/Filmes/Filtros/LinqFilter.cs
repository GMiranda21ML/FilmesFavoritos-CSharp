using Filmes.Interfaces;
using Filmes.Modelos;

namespace Filmes.Filtros;

internal class LinqFilter : IExibir
{
    public void ExibirFiltro(List<Filme> filmes)
    {
        Console.WriteLine("-----------------------------------------------");
        foreach (var filme in filmes)
        {
            filme.ExibirDetalhesDoFilme();
            Console.WriteLine("-----------------------------------------------");

        }
    }


    public static void FiltrarDepoisDoAno(List<Filme> filmes, int ano)
    {
        LinqFilter linqFilter = new();

        var filtro = filmes
            .OrderBy(filme => filme.AnoInteiro)
            .Where(filme => filme.AnoInteiro >= ano)
            .ToList();

        linqFilter.ExibirFiltro(filtro);


    }    


    public static void FiltrarAntesDoAno(List<Filme> filmes, int ano)
    {
        LinqFilter linqFilter = new();

        var filtro = filmes
            .OrderBy(filme => filme.AnoInteiro)
            .Where(filme => filme.AnoInteiro <= ano)
            .ToList();

        linqFilter.ExibirFiltro(filtro);


    }    
    

    public static void FiltrarDuranteOAno(List<Filme> filmes, int ano)
    {
        LinqFilter linqFilter = new();

        var filtro = filmes
            .OrderBy(filme => filme.Titulo)
            .Where(filme => filme.AnoInteiro == ano)
            .ToList();

        linqFilter.ExibirFiltro(filtro);


    }


    public static void FiltrarPorGenero(List<Filme> filmes, string genero)
    {
        LinqFilter linqFilter = new();
        var filtro = filmes
            .OrderBy(filme => filme.Titulo)
            .Where(filme => filme.UnicoGenero.Contains(genero))
            .ToList();

        linqFilter.ExibirFiltro(filtro);

    }

}
