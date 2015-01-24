using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries
{
    public enum DeviceScreens
    {
        WinPhone,
        Surface
    }

    public enum PhoneOrientations
    {
        Portrait = 0,
        Landscape = 90,
        PortraitFlipped = 180,
        LandscpeFlipped = 270
    }

    public enum SurfaceOrientations
    {
        Landscape = 0,
        Portrait = 90,
        LandscapeFlipped = 180,
        PortraitFlipped = 270
    }

    public class GameSettings
    {
        public const int TargetScreenWidth = 1920;
        public const int TargetScreenHeight = 1080;
        public static int CurrentScreenWidth { get; set; }
        public static int CurrentScreenHeight { get; set; }

        public static DeviceScreens DeviceType { get; set; }
        public static PhoneOrientations PhoneScreenOrientation { get; set; }
        public static SurfaceOrientations SurfaceScreenOrientation { get; set; }

        public static float ScreenScaleRatio { get; set; }
        public static float ScreenOffSetX { get; set; }
        public static float ScreenOffSetY { get; set; }

        public GameSettings ()
        {
            DeviceType = DeviceScreens.WinPhone;
            PhoneScreenOrientation = PhoneOrientations.Portrait;
            SurfaceScreenOrientation = SurfaceOrientations.Landscape;
            ScreenScaleRatio = 1.0f;
        }

        #region Images

        public const string DefaultImagePath = "Graphics/Default";

        #endregion
    }
}
