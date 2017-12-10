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
    public class WorkoutViewModel : BindableBase, INavigatedAware
    {
        INavigationService _navigationService;
        
      
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand<WorkoutItem> MoreCommand { get; set; }
        //public DelegateCommand<WorkoutItem> DeleteCommand { get; set; }
        


        private ObservableCollection<WorkoutItem> _WorkoutCollection = new ObservableCollection<WorkoutItem>();
        public ObservableCollection<WorkoutItem> WorkoutCollection
        {
            get { return _WorkoutCollection; }
            set { SetProperty(ref _WorkoutCollection, value); }

        }
        public WorkoutViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //    DeleteCommand = new DelegateCommand<WorkoutItem>(DeleteB);
            Populate();
            MoreCommand = new DelegateCommand<WorkoutItem>(MoreB);
            GoBackCommand = new DelegateCommand(GoBack);
           
        }
        //private void DeleteB(WorkoutItem workoutItem)
        //{
        //   _WorkoutCollection.Remove(workoutItem);
        //}
        private void Populate()
        {
            _WorkoutCollection.Add(new WorkoutItem { Details = "SIT UP", URL= "https://www.youtube.com/watch?v=1fbU_MkV7NE", IconSource = "SitUp", MDetails = "Lie on your back with your knees bent and feet flat on the floor. Place your fingertips behind your ears with your elbows pointed out.Without lifting your feet off the ground, curl your upper body upward toward your thighs. Keep your head in line with your body. Lower your upper body under control back to the ground." });
            _WorkoutCollection.Add(new WorkoutItem { Details = "AB CRUNCH", URL = "https://www.youtube.com/watch?v=Xyd_fa5zoEU", IconSource = "AbCrunch", MDetails = "A crunch begins with lying face up on the floor with knees bent. The movement begins by curling the shoulders towards the pelvis. The hands can be behind or beside the neck or crossed over the chest. Injury can be caused by pushing against the head or neck with hands." });
            _WorkoutCollection.Add(new WorkoutItem { Details = "DIP", URL = "https://www.youtube.com/watch?v=0326dy_-CzM", IconSource = "BenchDips", MDetails = "Grip the edge of your bench with your hands. Place your hands onto the edge of your bench, one hand on each side of your hips. Your palms should be down, fingertips pointing forward and towards the floor, and thumbs next to your hips.Lift your butt off of the bench. Use your arms to push your butt up and off the bench. Firmly grip the edge of the bench as you straighten your arms and extend your legs forward so that your knees are no longer bent. Walk your feet out slightly so that your butt is in front of the bench. This will be your starting positionSlowly lower your body by bending your elbows. Inhale as you lower your body towards the floor, and stop once your upper arms are parallel to the floor. You should have a right angle between your upper arms and the forearms, and your butt should be a few inches off the ground" });
            _WorkoutCollection.Add(new WorkoutItem { Details = "BENCH PRESS", URL = "https://www.youtube.com/watch?v=UZi_zwL3Oq0", IconSource = "BenchPress", MDetails = "Proper Bench Press form starts lying on a Bench with your feet on the floor. Unrack the bar with straight arms. Lower it to your mid-chest. Press it back up until you’ve locked your elbows. Keep your butt on the bench. " });
            _WorkoutCollection.Add(new WorkoutItem { Details = "BICEPS CURL", URL = "https://www.youtube.com/watch?v=4Hg2zJ_MBek", IconSource = "BicepCurl", MDetails = "While sitting on a bench with your feet firmly on the floor, place the back of your left upper arm on the inside of your thigh. Keep your arm on your thigh throughout. Put your right hand on the right knee for stability. Do your curls on the left side, then repeat on the right side. " });
            _WorkoutCollection.Add(new WorkoutItem { Details = "FRENCH PRESS", URL = "https://www.youtube.com/watch?v=wfFuClSLcME", IconSource = "FrenchPress", MDetails = "INITIAL POSITION: From a standing position, grasp an EZ bar loaded with the desired weight and raise it above your head extending your arms. Palms face forward. Don't bend your wrists. Slightly bend your knees to find a stable position. Keep your core tight. MOVEMENT: Lower the bar behind your head, slowly, focusing on the movement. Then lift it again to the initial position. Keep your elbows high in the same position, don't swing your arms. Lower and lift the bar in a semicircular arc behind your head. BREATHING: Inhale while you lower the bar, exhale while you lift it." });
            _WorkoutCollection.Add(new WorkoutItem { Details = "RUSSIAN TWIST", URL = "https://www.youtube.com/watch?v=drvh39387LY", IconSource = "RussianTwist", MDetails = "Sit with your torso leaning back at a 45-degree angle, knees bent, and your feet either on the floor or elevated a few inches. In most variations you hold something in front of your chest, usually a medicine ball or weight plate." });
            _WorkoutCollection.Add(new WorkoutItem { Details = "MILITARY PRESS", URL = "https://www.youtube.com/watch?v=waeCyaAQRn8", IconSource = "MilitaryPress", MDetails = "Start by placing a barbell that is about chest high on a squat rack. Once you have selected the weights, grab the barbell using a pronated (palms facing forward) grip. Make sure to grip the bar wider than shoulder width apart from each other. Slightly bend the knees and place the barbell on your collar bone. Lift the barbell up keeping it lying on your chest. Take a step back and position your feet shoulder width apart from each other. Once you pick up the barbell with the correct grip length, lift the bar up over your head by locking your arms. Hold at about shoulder level and slightly in front of your head. This is your starting position. Lower the bar down to the collarbone slowly as you inhale. Lift the bar back up to the starting position as you exhale. Repeat for the recommended amount of repetitions." });
            _WorkoutCollection.Add(new WorkoutItem { Details = "LEG RAISE", URL = "https://www.youtube.com/watch?v=JB2oyawG9KI", IconSource = "LegRaise", MDetails = "The leg raise is a strength training exercise which targets the iliopsoas (the interior hip flexors). Because the abdominal muscles are used isometrically to stabilize the body during the motion, leg raises are also often used to strengthen the rectus abdominis muscle and the internal and external oblique muscles" });
            _WorkoutCollection.Add(new WorkoutItem { Details = "LATERAL RAISE", URL = "https://www.youtube.com/watch?v=geenhiHju-o", IconSource = "LateralRaise", MDetails = "Grasp dumbbells in front of thighs with elbows slightly bent. Bend over slightly with hips and knees bent slightly. Raise upper arms to sides until elbows are shoulder height. Maintain elbows' height above or equal to wrists. Lower and repeat." });

            _WorkoutCollection.Add(new WorkoutItem { Details = "ARES", URL = "NONE", IconSource = "W1", MDetails = "3 sets: set1{10 reps of sit ups, 12 reps of Bicep curls, 10 reps os russian twist, 8 reps bench press}, set2{8 reps of sit ups, 10 reps of Bicep curls, 8 reps os russian twist, 6 reps bench press}, set3{10 reps of sit ups, 12 reps of Bicep curls, 10 reps os russian twist, 8 reps bench press}" });
            _WorkoutCollection.Add(new WorkoutItem { Details = "APOLLO", URL = "NONE", IconSource = "W2", MDetails = "3 sets: set1{10 reps of sit ups, 12 reps of Bicep curls, 10 reps os russian twist, 8 reps french press}, set2{8 reps of sit ups, 10 reps of Bicep curls, 8 reps os russian twist, 6 reps french press}, set3{10 reps of sit ups, 12 reps of Bicep curls, 10 reps os russian twist, 8 reps french press}" });
            _WorkoutCollection.Add(new WorkoutItem { Details = "CHRONOS", URL = "NONE", IconSource = "W3", MDetails = "3 sets: set1{10 reps of leg raises, 12 reps of Bicep curls, 10 reps os russian twist, 8 reps bench press}, set2{8 reps of leg raises, 10 reps of Bicep curls, 8 reps os russian twist, 6 reps bench press}, set3{10 reps of leg raisese, 12 reps of Bicep curls, 10 reps os russian twist, 8 reps bench press}" });
            _WorkoutCollection.Add(new WorkoutItem { Details = "DIONYSUS", URL = "NONE", IconSource = "W5", MDetails = "3 sets: set1{10 reps of sit ups, 12 reps of bench dips, 10 reps os russian twist, 8 reps bench press}, set2{8 reps of sit ups, 10 reps of bench dips, 8 reps os russian twist, 6 reps bench press}, set3{10 reps of sit ups, 12 reps of Bench dips, 10 reps os russian twist, 8 reps bench press}" });
            _WorkoutCollection.Add(new WorkoutItem { Details = "HERMES", URL = "NONE", IconSource = "W6", MDetails = "3 sets: set1{10 reps of military press, 12 reps of Bicep curls, 10 reps os russian twist, 8 reps bench press}, set2{8 reps of military press, 10 reps of Bicep curls, 8 reps os russian twist, 6 reps bench press}, set3{10 reps of military press, 12 reps of Bicep curls, 10 reps os russian twist, 8 reps bench press}" });
        }
        
       

        private async void MoreB(WorkoutItem workoutItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("WorkoutItemInfo", workoutItem);
            await _navigationService.NavigateAsync("MoreInfo", navParams);
        }
        private async void LinkB(WorkoutItem workoutItem)
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