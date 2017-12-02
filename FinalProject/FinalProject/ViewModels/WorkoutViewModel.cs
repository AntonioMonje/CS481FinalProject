using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms.Xaml;
using FinalProject.Model;
using System.Collections.ObjectModel;

namespace FinalProject.ViewModels
{
    public class WorkoutViewModel : BindableBase, INavigatedAware
    {
        INavigationService _navigationService;
        
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand<WorkoutItem> MoreCommand { get; set; }
         
       //public string Details { get; set; }
       //public string MDetails { get; set; }

        private ObservableCollection<WorkoutItem> _WorkoutCollection = new ObservableCollection<WorkoutItem>();
        public ObservableCollection<WorkoutItem> WorkoutCollection
        {
            get { return _WorkoutCollection; }
            set { SetProperty(ref _WorkoutCollection, value); }

        }
        public WorkoutViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;           
            MoreCommand = new DelegateCommand<WorkoutItem>(MoreB);
            GoBackCommand = new DelegateCommand(GoBack);
            var workoutItem = new WorkoutItem();
            _WorkoutCollection.Add(new WorkoutItem { Details = "it worked" });
        }
       
       
        private async void MoreB(WorkoutItem workoutItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("WorkoutItemInfo", workoutItem);
            await _navigationService.NavigateAsync("MoreInfo", navParams);
        }
        private void GoBack()
        {
            _navigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }
   
    }
}