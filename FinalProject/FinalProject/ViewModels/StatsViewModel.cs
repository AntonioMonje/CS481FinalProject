using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using System;
using System.Collections.Generic;
using System.Linq;
using SkiaSharp;
using Entry = Microcharts.Entry;
using Xamarin.Forms;
using SkiaSharp.Views.Forms;
using Microcharts;
using Microcharts.Forms;
using System.Collections.ObjectModel;
using FinalProject.Model;

namespace FinalProject.ViewModels
{
	public class StatsViewModel : BindableBase, INavigatedAware
	{
		INavigationService _navigationService;
       

        public DelegateCommand GoBackCommand { get; set; }

       
        public void Data()
        {
            var entries = new[]
{
                 new Entry(130)
    {
    Label = "Healthy",
    ValueLabel = "130+",
    Color = SKColor.Parse("#68B9C0")
    },
    new Entry(160)
    {
        Label = "Healthy to Average",
        ValueLabel = "160+",
    Color = SKColor.Parse("#266489")
    },
    new Entry(190)
    {
    Label = "Average to OverWeight",
    ValueLabel = "190+",
    Color = SKColor.Parse("#68B9C0")
    },
     new Entry(220)
    {
    Label = "OverWeight to Unhealthy",
    ValueLabel = "220+",
    Color = SKColor.Parse("#68B9C0")
    },
    new Entry(250)
    {
    Label = "Unhealthy",
    ValueLabel = "250+",
    Color = SKColor.Parse("#90D585")
    }
};
         
            var chart = new BarChart() { Entries = entries };
            

        }

		public StatsViewModel(INavigationService navigationService)
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

            Data(); 
		}
	}
}

