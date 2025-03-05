using System;
using Xamarin.Forms;
using ZXing.Mobile;

namespace WarehouseApp.Views
{
    public partial class ScanPage : ContentPage
    {
        private readonly ApiService _apiService; // Объявление поля

        public ScanPage()
        {
            InitializeComponent();
            _apiService = new ApiService(); // Инициализация поля
        }

        private async void OnScanClicked(object sender, EventArgs e) // Удален третий параметр
        {
            var scanner = new MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result != null)
            {
                var product = await _apiService.GetProductByBarcode(result.Text);
                await DisplayAlert("Товар", $"Название: {product.Name}\nКоличество: {product.Quantity}", "OK");
            }
        }
    }
}