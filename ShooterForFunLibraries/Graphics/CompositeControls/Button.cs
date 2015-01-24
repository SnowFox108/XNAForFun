using Microsoft.Xna.Framework;
using ShooterForFunLibraries.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Graphics
{
    public class Button : Label
    {
        public MouseButtons MouseButtonClick { get; set; }
        public event EventHandler OnClick;

        public Button() : base() 
        {
            this.MouseButtonClick = MouseButtons.Left;
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.Instance.EnableMouse)
            {
                if (InputManager.Instance.Mouse.ButtonClicked(TargetRect, MouseButtonClick))
                    OnClick(this, new EventArgs());
            }
            if (InputManager.Instance.EnableTouch)
            {
                if (InputManager.Instance.Touch.Touched(TargetRect))
                    OnClick(this, new EventArgs());
                if (GameSettings.DeviceType == DeviceScreens.WinPhone)
                {
                    if (InputManager.Instance.Touch.Touched())
                        OnClick(this, new EventArgs());
                }
            }

            base.Update(gameTime);
        }

        public void RaiseClick()
        {
            OnClick(this, new EventArgs());
        }
        
    }
}
