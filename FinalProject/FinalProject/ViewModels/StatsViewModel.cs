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

namespace FinalProject.ViewModels
{
	public class StatsViewModel : BindableBase, INavigatedAware
	{
		INavigationService _navigationService;
       

        public DelegateCommand GoBackCommand { get; set; }
        public object ChartView { get; private set; }
        public object MyListview { get; private set; }
        public BarChart ChartData { get; private set; }

        public void Data()
        {
     var entries = new[]
{
    new Entry(200)
    {
        Label = "January",
        ValueLabel = "200",
        Color = SKColor.Parse("#266489")
    },
    new Entry(400)
    {
        Label = "February",
        ValueLabel = "400",
        Color = SKColor.Parse("#68B9C0")
    },
    new Entry(-100)
    {
        Label = "March",
        ValueLabel = "-100",
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

