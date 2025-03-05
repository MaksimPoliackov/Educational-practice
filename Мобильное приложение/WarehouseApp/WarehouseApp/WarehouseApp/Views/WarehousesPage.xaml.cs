using System.Collections.Generic;
using Xamarin.Forms;

namespace WarehouseApp.Views
{
    public partial class WarehousesPage : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();

        public WarehousesPage()
        {
            InitializeComponent();
            LoadWarehouses();
        }

        private async void LoadWarehouses()
        {
            var warehouses = await _apiService.GetWarehouses();
            WarehousesListView.ItemsSource = warehouses;
        }
    }
}