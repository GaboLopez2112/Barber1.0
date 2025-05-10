//using BarberApp.Services;
//namespace BarberApp.Views;

//    public partial class RegisterPage : ContentPage
//{
//    public RegisterPage()
//    {
//        InitializeComponent();
//        RolePicker.SelectedIndex = 1;
//    }

//    private async void OnRegisterClicked(object sender, EventArgs e)
//    {
//        bool success = await DatabaseService.RegisterUser(
//            UsernameEntry.Text,
//            PasswordEntry.Text,
//            RolePicker.SelectedItem?.ToString());

//        if (success)
//        {
//            await DisplayAlert("Éxito", "Usuario registrado correctamente", "OK");
//            await Navigation.PopAsync(); // 👈 Volver al Login
//        }
//        else
//        {
//            StatusLabel.Text = "Usuario ya existe.";
//        }
//    }
//}

