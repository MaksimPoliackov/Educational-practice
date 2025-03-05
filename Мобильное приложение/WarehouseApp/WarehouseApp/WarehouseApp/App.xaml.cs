using System;
using WarehouseApp.Views; // Убедитесь, что это пространство имен правильно указывает на вашу MainPage
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WarehouseApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Установка главной страницы приложения
            MainPage = new NavigationPage(new MainPage()); // Убедитесь, что MainPage наследует от ContentPage
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}