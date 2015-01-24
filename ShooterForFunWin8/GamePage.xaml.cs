using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MonoGame.Framework;
using ShooterForFunLibraries;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.Graphics.Display;


namespace ShooterForFunWin8
{
    /// <summary>
    /// The root page used to display the game.
    /// </summary>
    public sealed partial class GamePage : SwapChainBackgroundPanel
    {
        readonly ShooterGame _game;

        public GamePage(string launchArguments)
        {
            this.InitializeComponent();

            GameSettings.DeviceType = DeviceScreens.Surface;
            GetDisplayOrientation();

            Window.Current.SizeChanged += Current_SizeChanged;
            // Create the game.
            _game = XamlGame<ShooterGame>.Create(launchArguments, Window.Current.CoreWindow, this);
        }

        protected void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            GetDisplayOrientation();
        }

        private static void GetDisplayOrientation()
        {
            switch (DisplayProperties.CurrentOrientation)
            {
                case DisplayOrientations.Landscape:
                    GameSettings.SurfaceScreenOrientation = SurfaceOrientations.Landscape;
                    break;
                case DisplayOrientations.LandscapeFlipped:
                    GameSettings.SurfaceScreenOrientation = SurfaceOrientations.LandscapeFlipped;
                    break;
            }
        }

    }
}
