using Microsoft.Extensions.DependencyInjection;

namespace P7_Analisis05
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Poemas();
        }
    }
}