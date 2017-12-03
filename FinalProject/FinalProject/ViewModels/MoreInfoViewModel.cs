using Prism.Commands;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms.Xaml;
using FinalProject.Model;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FinalProject.ViewModels
{
    public class MoreInfoViewModel : BindableBase, INavigatedAware
    {
        INavigationService _navigationService;

        public DelegateCommand GoBackCommand { get; set; }
        private WorkoutItem _workoutItem;
        public WorkoutItem WorkoutItem
        {
            get { return _workoutItem; }
            set { SetProperty(ref _workoutItem, value); }
        }

        public MoreInfoViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoBackCommand = new DelegateCommand(GoBack);
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
            if (parameters.ContainsKey("WorkoutItemInfo"))
            {
                WorkoutItem = (WorkoutItem)parameters["WorkoutItemInfo"];
            }
        }
    }
}

