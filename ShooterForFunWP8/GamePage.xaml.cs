using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework;
using MonoGame.Framework.WindowsPhone;
using ShooterForFunWP8.Resources;
using ShooterForFunLibraries;

namespace ShooterForFunWP8
{
    public partial class GamePage : PhoneApplicationPage
    {
        
        private ShooterGame _game;
        //static internal PageOrientation PageOrientation = PageOrientation.Portrait;
        public static GamePage Instance;

        // Constructor
        public GamePage()
        {
            InitializeComponent();

            if (Instance == null)
                Instance = this;

            GameSettings.DeviceType = DeviceScreens.WinPhone;
            GameSettings.PhoneScreenOrientation = PhoneOrientations.Landscape;

            _game = XamlGame<ShooterGame>.Create("", new PhoneApplicationPage());

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        protected override void OnOrientationChanged(OrientationChangedEventArgs e)
        {
            switch (e.Orientation)
            {
                case PageOrientation.LandscapeLeft:
                    GameSettings.PhoneScreenOrientation = PhoneOrientations.Landscape;
                    break;
                case PageOrientation.LandscapeRight:
                    GameSettings.PhoneScreenOrientation = PhoneOrientations.LandscpeFlipped;
                    break;
            }
            base.OnOrientationChanged(e);
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}