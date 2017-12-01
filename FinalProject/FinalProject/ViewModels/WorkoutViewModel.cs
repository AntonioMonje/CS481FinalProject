using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms.Xaml;
using static FinalProject.Model.WorkoutItemModel;
using System.Collections.ObjectModel;

namespace FinalProject.ViewModels
{
    public class WorkoutViewModel : BindableBase, INavigatedAware
    {
        INavigationService _navigationService;
        
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand<WorkoutItem> DeleteCommand { get; set; }
        public DelegateCommand<WorkoutItem> MoreCommand { get; set; }
         
        
        private ObservableCollection<WorkoutItem> _WorkoutCollection = new ObservableCollection<WorkoutItem>();
        public ObservableCollection<WorkoutItem> WorkoutCollection
        {
            get { return _WorkoutCollection; }
            set { SetProperty(ref _WorkoutCollection, value); }

        }
        public WorkoutViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            DeleteCommand = new DelegateCommand<WorkoutItem>(DeleteB);
            MoreCommand = new DelegateCommand<WorkoutItem>(MoreB);
            GoBackCommand = new DelegateCommand(GoBack);
                   
        }
       
        private void Populate()
        {
            var workoutList = new WorkoutItem()
            {
                Details = "Noragami",
                MDetails = "This is is an Anime about Heros who fight villians. A weak kid with no powerr gets the powers of the strongest hero and tries to become a hero"
            };
            WorkoutCollection.Add(workoutList);
        }
     
        private void DeleteB(WorkoutItem workoutItem)
        {
            _WorkoutCollection.Remove(workoutItem);
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