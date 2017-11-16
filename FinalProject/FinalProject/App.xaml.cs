using Prism.Unity;
using FinalProject.Views;
using Xamarin.Forms;

namespace FinalProject
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<Workout>();
            Container.RegisterTypeForNavigation<Stats>();
            Container.RegisterTypeForNavigation<Qoutes>();
        }
    }
}
