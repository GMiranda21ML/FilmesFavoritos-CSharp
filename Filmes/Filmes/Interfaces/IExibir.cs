using Filmes.Modelos;

namespace Filmes.Interfaces;

internal interface IExibir
{
    public void ExibirFiltro(List<Filme> filmes);
}
