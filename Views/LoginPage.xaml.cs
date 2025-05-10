using BarberApp.Models;
//using BarberApp.Services;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text;
namespace BarberApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string usuario = UsernameEntry.Text;
        string contrasena = PasswordEntry.Text;

        var cliente = new HttpClient();
        var url = "http://localhost:8080/api/auth/login"; // Ajusta si usas emulador Android o dispositivo físico

        var datosLogin = new
        {
            usuario = usuario,
            contrasena = contrasena
        };

        var contenido = new StringContent(JsonConvert.SerializeObject(datosLogin), Encoding.UTF8, "application/json");

        try
        {
            var respuesta = await cliente.PostAsync(url, contenido);
            if (respuesta.IsSuccessStatusCode)
            {
                var json = await respuesta.Content.ReadAsStringAsync();
                var usuarioAutenticado = JsonConvert.DeserializeObject<UserModel>(json);

                await DisplayAlert("Bienvenido", $"Hola {usuarioAutenticado.nombreUsuario} - Rol: {usuarioAutenticado.rol}", "OK");

                App.UsuarioActual = usuarioAutenticado;
                await Navigation.PushAsync(new PanelPrincipal());

                await Navigation.PushAsync(new PanelPrincipal());
            }
            else
            {
                await DisplayAlert("Error", "Credenciales incorrectas", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Fallo de conexión: {ex.Message}", "OK");
        }
    }

}