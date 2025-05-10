using BarberApp.Models;
using BarberApp.Views;
namespace BarberApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // 👇 Aquí se configura el NavigationPage con LoginPage como inicial
            var navPage = new NavigationPage(new LoginPage());

            return new Window(navPage);
        }
        public static UserModel UsuarioActual { get; set; }
    }
}
