using System;
using Xamarin.Forms;

namespace WarehouseApp.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            var loginResponse = await _apiService.Login(username, password);
            if (loginResponse.IsSuccess)
            {
                await Navigation.PushAsync(new VerifyPage(loginResponse.Token));
            }
            else
            {
                await DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
            }
        }
    }
}