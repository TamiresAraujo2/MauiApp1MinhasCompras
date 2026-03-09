using Microsoft.Extensions.DependencyInjection;

namespace MauiApp1MinhasCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new Views.LIstaProduto());
            // navigationPage é a página de navegação, e a LIstaProduto
            // é a página inicial que será exibida dentro da navegação.
        }


    }
}
