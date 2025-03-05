using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace WarehouseApp.Views
{
    public partial class VerifyPage : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();
        private readonly string _token;


        public VerifyPage(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private async void OnVerifyClicked(object sender, EventArgs e)
        {
            var code = CodeEntry.Text;
            var verifyResponse = await _apiService.Verify(code);

            if (verifyResponse.IsSuccess)
            {
                await SecureStorage.SetAsync("auth_token", _token);
                await Navigation.PushAsync(new MainPage()); // Убедитесь, что MainPage наследует от Page
            }
            else
            {
                await DisplayAlert("Ошибка", "Неверный код подтверждения", "OK");
            }
        }
    }
}