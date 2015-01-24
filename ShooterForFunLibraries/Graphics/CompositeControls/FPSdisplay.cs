using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Graphics
{
    public class FPSdisplay : TextMessage
    {
        public bool IsShow { get; set; }

        private float elapsedTime, totalFrames, fps;

        public FPSdisplay()
            : base()
        {
            IsShow = true;
        }

        public override void Update(GameTime gameTime)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            totalFrames++;

            if (elapsedTime >= 1.0f)
            {
                fps = totalFrames;
                totalFrames = 0;
                elapsedTime = 0;
            }

            Text = string.Format("FPS: {0} Resolution: {1}*{2} Time Elapsed: {3}", fps, GameSettings.CurrentScreenWidth, GameSettings.CurrentScreenHeight, gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }
    }
}
