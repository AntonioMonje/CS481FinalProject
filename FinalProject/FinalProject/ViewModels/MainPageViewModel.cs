using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.CompilerServices;



namespace FinalProject.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand NavToNewPage1Command { get; set; }
        public DelegateCommand NavToNewPage2Command { get; set; }
        public DelegateCommand NavToNewPage3Command { get; set; }

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

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavToNewPage1Command = new DelegateCommand(NavToNewPage1);
            NavToNewPage2Command = new DelegateCommand(NavToNewPage2);
            NavToNewPage3Command = new DelegateCommand(NavToNewPage3);
            Title = "Xamarin Forms Application + Prism";
            ButtonText = "Add Name";
        }

        INavigationService _navigationService;
        private async void NavToNewPage1()
        {
            var navParams = new NavigationParameters();
            navParams.Add("NavFromPage", "MainPageViewModel");
            await _navigationService.NavigateAsync("Workout", navParams);
        }
        private async void NavToNewPage2()
        {
            var navParams = new NavigationParameters();
            navParams.Add("NavFromPage", "MainPageViewModel");
            await _navigationService.NavigateAsync("Qoutes", navParams);
        }
        private async void NavToNewPage3()
        {
            var navParams = new NavigationParameters();
            navParams.Add("NavFromPage", "MainPageViewModel");
            await _navigationService.NavigateAsync("Stats", navParams);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
