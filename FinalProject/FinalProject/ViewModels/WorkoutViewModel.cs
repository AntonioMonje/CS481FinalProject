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
        public DelegateCommand<WorkoutItem> DeleteCommand { get; set; }
        public DelegateCommand<WorkoutItem> AddCommand { get; set; }

        public WorkoutViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            DeleteCommand = new DelegateCommand<WorkoutItem>(DeleteB);
            AddCommand = new DelegateCommand<WorkoutItem>(AddB);
            GoBackCommand = new DelegateCommand(GoBack);
          
        }
        private ObservableCollection<WorkoutItem> _WorkoutCollection = new ObservableCollection<WorkoutItem>();
        public ObservableCollection<WorkoutItem> WorkoutCollection
        {
            get { return _WorkoutCollection; }
            set { SetProperty(ref _WorkoutCollection, value); }

        }
     
        private void DeleteB(WorkoutItem workoutItem)
        {
            _WorkoutCollection.Remove(workoutItem);
        }
        private void AddB(WorkoutItem workoutItem)
        {
            _WorkoutCollection.Remove(workoutItem);
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