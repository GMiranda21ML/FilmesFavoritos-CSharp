using System.Globalization;

namespace Filmes.Menus;

internal class Menu
{
    public void Titulo()
    {
        Console.WriteLine(@"
███╗░░░███╗███████╗██╗░░░██╗░██████╗  ███████╗██╗██╗░░░░░███╗░░░███╗███████╗░██████╗
████╗░████║██╔════╝██║░░░██║██╔════╝  ██╔════╝██║██║░░░░░████╗░████║██╔════╝██╔════╝
██╔████╔██║█████╗░░██║░░░██║╚█████╗░  █████╗░░██║██║░░░░░██╔████╔██║█████╗░░╚█████╗░
██║╚██╔╝██║██╔══╝░░██║░░░██║░╚═══██╗  ██╔══╝░░██║██║░░░░░██║╚██╔╝██║██╔══╝░░░╚═══██╗
██║░╚═╝░██║███████╗╚██████╔╝██████╔╝  ██║░░░░░██║███████╗██║░╚═╝░██║███████╗██████╔╝
╚═╝░░░░░╚═╝╚══════╝░╚═════╝░╚═════╝░  ╚═╝░░░░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚══════╝╚═════╝░

███████╗░█████╗░██╗░░░██╗░█████╗░██████╗░██╗████████╗░█████╗░░██████╗
██╔════╝██╔══██╗██║░░░██║██╔══██╗██╔══██╗██║╚══██╔══╝██╔══██╗██╔════╝
█████╗░░███████║╚██╗░██╔╝██║░░██║██████╔╝██║░░░██║░░░██║░░██║╚█████╗░
██╔══╝░░██╔══██║░╚████╔╝░██║░░██║██╔══██╗██║░░░██║░░░██║░░██║░╚═══██╗
██║░░░░░██║░░██║░░╚██╔╝░░╚█████╔╝██║░░██║██║░░░██║░░░╚█████╔╝██████╔╝
╚═╝░░░░░╚═╝░░╚═╝░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝╚═╝░░░╚═╝░░░░╚════╝░╚═════╝░");

        Console.WriteLine(@"
Digite 1 para adicionar um filme
Digite 2 para visualizar todos os filme
Digite 3 para deletar um filme
Digite 0 para sair");
    }


    public void LimparTela()
    {
        Console.Write("Digite qualquer tecla para voltar ao menu: ");
        Console.ReadKey();
    }


    public static string ToTitleCase(string texto)
    {
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        TextInfo textInfo = cultureInfo.TextInfo;

        return textInfo.ToTitleCase(texto);
    }
}
