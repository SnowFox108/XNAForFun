using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Inputs
{
    public class InputTouchState
    {

        private class TouchState
        {
            public TouchLocationState LocationState { get; set; }
        }

        private TouchCollection currentTouchState;
        public bool IsReadingInput { get; set; }

        public void Update()
        {
            if (IsReadingInput)
                currentTouchState = TouchPanel.GetState();
            else
                currentTouchState.Clear();
        }

        public bool Touched()
        {
            return currentTouchState.Where(t => t.State == TouchLocationState.Pressed || t.State == TouchLocationState.Moved).Count() > 0;
        }

        public bool Touched(Rectangle region)
        {
            //return currentTouchState.Where(t => t.State == TouchLocationState.Pressed && region.Contains(GetPoint(t.Position))).Count() > 0;
            int count = 0;
            foreach (TouchLocation location in currentTouchState)
            {
                if ((location.State == TouchLocationState.Pressed || location.State == TouchLocationState.Moved) && region.Contains(GetPoint(location.Position)))
                    count++;
            }
            return count > 0;
        }

        public bool SignleTouched(Rectangle region)
        {
            int result = currentTouchState.Where(t => t.State == TouchLocationState.Pressed && region.Contains(GetPoint(t.Position))).Count();
            return (result > 0 && result < 2);
        }

        private Point GetPoint(Vector2 position)
        {
            switch (GameSettings.DeviceType)
            {
                case DeviceScreens.Surface:
                    return new Point((int)(position.X / GameSettings.ScreenScaleRatio + GameSettings.ScreenOffSetX),
                        (int)(position.Y / GameSettings.ScreenScaleRatio + GameSettings.ScreenOffSetY));
                case DeviceScreens.WinPhone:
                    switch (GameSettings.PhoneScreenOrientation)
                    {
                        case PhoneOrientations.Landscape:
                            return new Point((int)(position.X / GameSettings.ScreenScaleRatio + GameSettings.ScreenOffSetX),
                                (int)(position.Y / GameSettings.ScreenScaleRatio + GameSettings.ScreenOffSetY));

                        case PhoneOrientations.LandscpeFlipped:
                            return new Point((int)(position.X / GameSettings.ScreenScaleRatio + GameSettings.ScreenOffSetX),
                                (int)(position.Y / GameSettings.ScreenScaleRatio + GameSettings.ScreenOffSetY));

                    }
                    break;
            }
            return new Point((int)position.X, (int)position.Y);
        }

        public Vector2 UpdateByFreeDrag (Vector2 position)
        {
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                if (gesture.GestureType == GestureType.FreeDrag)
                    position += gesture.Delta;
            }
            return position;
        }
    }
}
