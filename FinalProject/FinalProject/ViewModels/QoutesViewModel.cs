using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using static FinalProject.Model.QouteItemModel;
using System.Runtime.CompilerServices;


namespace FinalProject.ViewModels
{
    public class QoutesViewModel : BindableBase, INavigatedAware
    {
        INavigationService _navigationService;

        public DelegateCommand GoBackCommand { get; set; }

        

        public QoutesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoBackCommand = new DelegateCommand(GoBack);
        }

        private void GoBack()
        {
            _navigationService.GoBackAsync();
        }
        private ObservableCollection<GettingStarted> _QouteCollection = new ObservableCollection<GettingStarted>();
        public ObservableCollection<GettingStarted> QouteCollection
        {
            get { return _QouteCollection; }
            set { SetProperty(ref _QouteCollection, value); }

        }
       
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
           
        }
    }
}
