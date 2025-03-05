using System;
using Xamarin.Forms;
using WarehouseApp.Views;

namespace WarehouseApp.Views
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnWarehousesClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new WarehousesPage());
            IsPresented = false; // Закрыть меню
        }

        private void OnProductsClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ProductsPage());
            IsPresented = false; // Закрыть меню
        }

        private void OnScanClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ScanPage());
            IsPresented = false; // Закрыть меню
        }

        private void OnProfileClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ProfilePage());
            IsPresented = false; // Закрыть меню
        }
    }
}