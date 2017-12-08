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
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using OxyPlot.Axes;

namespace FinalProject.ViewModels
{
	public class StatsViewModel : BindableBase, INavigatedAware
	{
		INavigationService _navigationService;
        

        public DelegateCommand GoBackCommand { get; set; }
        public PlotModel Model { get; set; }
        public PlotModel Model2 { get; set; }



        public StatsViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
            HealthBarChart();
			GoBackCommand = new DelegateCommand(GoBack);
            PieChat();
        }

        private void HealthBarChart()
        {
            CategoryAxis xaxis = new CategoryAxis();
            xaxis.Position = AxisPosition.Bottom;

            xaxis.MajorGridlineStyle = LineStyle.Solid;
            xaxis.MinorGridlineStyle = LineStyle.Dot;
            xaxis.MajorGridlineColor = OxyColor.FromRgb(255, 255, 224);
            xaxis.MinorGridlineColor = OxyColor.FromRgb(255, 255, 224);
            xaxis.Labels.Add("Weight,130");

            xaxis.Labels.Add("160");

            xaxis.Labels.Add("190");

            xaxis.Labels.Add("220");


            LinearAxis yaxis = new LinearAxis();
            yaxis.Position = AxisPosition.Left;
            yaxis.MajorGridlineStyle = LineStyle.Dot;
            xaxis.MinorGridlineStyle = LineStyle.Dot;
          
            ColumnSeries s1 = new ColumnSeries();
            s1.IsStacked = true;
            s1.Items.Add(new ColumnItem(130));

            s1.Items.Add(new ColumnItem(160));

            s1.Items.Add(new ColumnItem(190));

            s1.Items.Add(new ColumnItem(220));

            ColumnSeries s2 = new ColumnSeries();
            s2.IsStacked = true;
            s2.Items.Add(new ColumnItem(30));

            s2.Items.Add(new ColumnItem(30));

            s2.Items.Add(new ColumnItem(30));

            s2.Items.Add(new ColumnItem(30));

            Model = new PlotModel();
            Model.Title = "Health Bar Chart";
            Model.TextColor = OxyColor.FromRgb(255, 255, 224);
          

            Model.Axes.Add(xaxis);
            Model.Axes.Add(yaxis);
            Model.Series.Add(s1);
            Model.Series.Add(s2);
        }

        private void PieChat()
        {
            Model2 = new PlotModel { Title = "World population by continent" };
            Model2.TextColor = OxyColor.FromRgb(255, 255, 224);
            
            var ps = new PieSeries
            {
                StrokeThickness = .75,
                InsideLabelPosition = .50,
                AngleSpan = 360,
                StartAngle = 0
            };

            dynamic seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            seriesP1.Slices.Add(new PieSlice("Healthy", 1030) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            seriesP1.Slices.Add(new PieSlice("Average", 929) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Overweight", 4157) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Underweight", 739) { IsExploded = true });
            Model2.Series.Add(seriesP1);
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

