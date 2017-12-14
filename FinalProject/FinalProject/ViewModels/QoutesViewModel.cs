using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Android.Media;
using Xamanimation;
using Xamanimation.Extensions;
using Xamanimation.Helpers;
using static FinalProject.Models.WeatherItemModel;

namespace FinalProject.ViewModels
{
    public class QoutesViewModel : BindableBase, INavigatedAware
    {
        INavigationService _navigationService;

        public DelegateCommand<WeatherItem> DeleteCommand { get; set; }
        public DelegateCommand NavToNewPageCommand { get; set; }
        public DelegateCommand GetWeatherForLocationCommand { get; set; }
        public DelegateCommand<WeatherItem> NavToMoreInfoPageCommand { get; set; }

        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _locationEnteredByUser;
        public string LocationEnteredByUser
        {
            get { return _locationEnteredByUser; }
            set { SetProperty(ref _locationEnteredByUser, value); }
        }

        private ObservableCollection<WeatherItem> _weatherCollection = new ObservableCollection<WeatherItem>();
        public ObservableCollection<WeatherItem> WeatherCollection
        {
            get { return _weatherCollection; }
            set { SetProperty(ref _weatherCollection, value); }
        }
        

        public QoutesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            DeleteCommand = new DelegateCommand<WeatherItem>(DeleteB);
            GetWeatherForLocationCommand = new DelegateCommand(GetWeatherForLocation);
            NavToMoreInfoPageCommand = new DelegateCommand<WeatherItem>(NavToMoreInfoPage);

        
        }
       
        private void GoBack()
        {
            _navigationService.GoBackAsync();
        }
       

        private void DeleteB(WeatherItem weatherItem)
        {
            _weatherCollection.Remove(weatherItem);
        }
        private async void NavToMoreInfoPage(WeatherItem weatherItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("WeatherItemInfo", weatherItem);
            await _navigationService.NavigateAsync("MorePage", navParams);
        }

        internal async void GetWeatherForLocation()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(
                string.Format(
                    $"http://api.openweathermap.org/data/2.5/weather?q={LocationEnteredByUser}&units=imperial&APPID=" +
                    $"fc1eb676c79af15d04d5bdb88276996a"));
            var response = await client.GetAsync(uri);
            WeatherItem weatherData = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                weatherData = WeatherItem.FromJson(content);
            }
            WeatherCollection.Add(weatherData);
        }



        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
           
        }
    }
}
