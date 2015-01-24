using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Inputs
{

    public enum MouseButtons
    {
        Left,
        Middle,
        Right,
        Extra1,
        Extra2
    }


    public class InputMouseState
    {
        private MouseState currentMouseState;
        private MouseState previousMouseState;

        public bool IsReadingInput { get; set; }

        public Vector2 Position
        {
            get
            {
                switch (GameSettings.DeviceType)
                {
                    case DeviceScreens.Surface:
                        return new Vector2(currentMouseState.X / GameSettings.ScreenScaleRatio + GameSettings.ScreenOffSetX,
                            currentMouseState.Y / GameSettings.ScreenScaleRatio + GameSettings.ScreenOffSetY);
                }
                return new Vector2(currentMouseState.X, currentMouseState.Y);
            }
        }

        public Point PositionP
        {
            get
            {
                switch (GameSettings.DeviceType)
                {
                    case DeviceScreens.Surface:
                        return new Point((int)(currentMouseState.X / GameSettings.ScreenScaleRatio + GameSettings.ScreenOffSetX),
                            (int)(currentMouseState.Y / GameSettings.ScreenScaleRatio + GameSettings.ScreenOffSetY));
                }
                return new Point(currentMouseState.X, currentMouseState.Y);
            }
        }

        private readonly IDictionary<MouseButtons, TimeSpan> mouseButtonHeldTimes;
        private readonly IDictionary<MouseButtons, Func<MouseState, ButtonState>> mouseButtonMaps;

        public InputMouseState()
        {
            mouseButtonMaps = new Dictionary<MouseButtons, Func<MouseState, ButtonState>>
            {
                    { MouseButtons.Left, s => s.LeftButton },
                    { MouseButtons.Right, s => s.RightButton },
                    { MouseButtons.Middle, s => s.MiddleButton },
                    { MouseButtons.Extra1, s => s.XButton1 },
                    { MouseButtons.Extra2, s => s.XButton2 }
            };

            mouseButtonHeldTimes = new Dictionary<MouseButtons, TimeSpan>();
            foreach (var mouseButton in Enum.GetValues(typeof(MouseButtons)))
            {
                mouseButtonHeldTimes.Add((MouseButtons)mouseButton, TimeSpan.Zero);
            }
        }

        public void Update()
        {
            previousMouseState = currentMouseState;
            if (IsReadingInput)
                currentMouseState = Mouse.GetState();
        }
        
        public bool ButtonClicked(MouseButtons button)
        {
            return mouseButtonMaps[button](currentMouseState) == ButtonState.Released && 
                mouseButtonMaps[button](previousMouseState) == ButtonState.Pressed;
        }

        public bool ButtonClicked(Rectangle region, MouseButtons button)
        {
            return (ButtonClicked(button) && region.Contains(PositionP));
        }

        public bool ButtonReleased(MouseButtons button)
        {
            return mouseButtonMaps[button](currentMouseState) == ButtonState.Released;
        }

        public bool ButtonDown(MouseButtons button)
        {
            return mouseButtonMaps[button](currentMouseState) == ButtonState.Pressed;
        }

        public bool MouseIsScrollingUp()
        {
            return currentMouseState.ScrollWheelValue > previousMouseState.ScrollWheelValue;
        }

        public bool MouseIsScrollingDown()
        {
            return currentMouseState.ScrollWheelValue < previousMouseState.ScrollWheelValue;
        }

        public TimeSpan GetElapsedHeldTime(MouseButtons mouseButton)
        {
            return mouseButtonHeldTimes[mouseButton];
        }

    }
}
