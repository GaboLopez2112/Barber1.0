namespace BarberApp.Views;

public partial class PanelPrincipal : ContentPage
{
	public PanelPrincipal()
	{
		InitializeComponent();
        CargarResumenDelDia();
    }
    private async void CargarResumenDelDia()
    {
        try
        {
            var barberService = new BarberService();
            if (App.UsuarioActual == null)
            {
                await DisplayAlert("Error", "No hay usuario autenticado", "OK");
                return;
            }

            var resumen = await barberService.ObtenerResumenDiaAsync(App.UsuarioActual.id);
            lblCortes.Text = resumen.Cortes.ToString();
            lblIngresos.Text = $"${resumen.Ingresos:0.00}";

        }
        catch (Exception ex)
        {

            await DisplayAlert("Error", "No se pudo cargar el resumen: " + ex.Message, "OK");
        }
        

        
    }
    private async void OnRegistrarCorteClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrarCortePage());
    }

    // Evento cuando el barbero hace clic en "Historial de Servicios"
    private async void OnHistorialClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistorialPage());
    }
}