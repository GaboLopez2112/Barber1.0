using BarberApp.Models;
using BarberApp.Services;

namespace BarberApp.Views;

public partial class RegistrarCortePage : ContentPage
{
    string fotoBase64 = null;
    
    public RegistrarCortePage()
	{
		InitializeComponent();
	}
    private async void OnSubirComprobanteClicked(object sender, EventArgs e)
    {

    }
    private async void OnMetodoPagoChanged(object sender, EventArgs e)
    {
        

    }
    private async void OnRegistrarCorteClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTipoCorte.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text) || pickerFormaPago.SelectedItem == null)
        {
            await DisplayAlert("Error", "Completa todos los campos", "OK");
            return;
        }

        if (pickerFormaPago.SelectedItem.ToString() == "Transferencia" && fotoBase64 == null)
        {
            await DisplayAlert("Error", "Debes subir el comprobante de pago", "OK");
            return;
        }

        var corte = new CorteModel
        {
            //fecha = DateTime.Now,
            tipoCorte = txtTipoCorte.Text,
            precio = decimal.Parse(txtPrecio.Text),
            formaPago = pickerFormaPago.SelectedItem.ToString(),
            fotoComprobante = fotoBase64,
            idBarbero = App.UsuarioActual.id
        };

        var corteService = new CorteService();
        var exito = await corteService.RegistrarCorteAsync(corte);
        if (exito)
        {
            await DisplayAlert("Éxito", "Corte registrado correctamente", "OK");
            await Navigation.PopAsync(); // Vuelve al panel
        }
        else
        {
            await DisplayAlert("Error", "No se pudo registrar el corte", "OK");
        }

    }
    private async void OnSeleccionarImagenClicked(object sender, EventArgs e)
    {
        try
        {
            var photo = await MediaPicker.PickPhotoAsync();
            if (photo != null)
            {
                var stream = await photo.OpenReadAsync();
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                fotoBase64 = Convert.ToBase64String(ms.ToArray());
                imgComprobante.Source = ImageSource.FromStream(() => new MemoryStream(ms.ToArray()));
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo seleccionar la imagen: {ex.Message}", "OK");
        }

    }
    private async void OnFormaPagoChanged(object sender, EventArgs e)
    {
        var pago = pickerFormaPago.SelectedItem?.ToString();
        comprobanteLayout.IsVisible = pago == "Transferencia";

    }
}