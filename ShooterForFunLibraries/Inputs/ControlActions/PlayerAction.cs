using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ShooterForFunLibraries.Graphics;
using ShooterForFunLibraries.Inputs;
using ShooterForFunLibraries.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries
{
    public class PlayerAction
    {
        public void PlayerMove(Image player, float speed)
        {
            int maxAction = 1;
            int action = 0;

            if (InputManager.Instance.EnableMouse)
            {
                if (InputManager.Instance.Mouse.ButtonDown(MouseButtons.Left))
                {
                    Vector2 posDelta = InputManager.Instance.Mouse.Position - player.Position;
                    posDelta.Normalize();
                    posDelta = posDelta * speed;
                    player.Position = player.Position + posDelta;
                    action++;
                }
            }
            if (action < maxAction && InputManager.Instance.EnableTouch)
            {
                if (InputManager.Instance.Touch.Touched())
                {
                    player.Position = InputManager.Instance.Touch.UpdateByFreeDrag(player.Position);
                    action++;
                }
            }
            if (action < maxAction && InputManager.Instance.EnableKeyBoard)
            {
                if (InputManager.Instance.KeyBoard.KeyDown(Keys.Left))
                    player.Position.X -= speed;
                if (InputManager.Instance.KeyBoard.KeyDown(Keys.Right))
                    player.Position.X += speed;
                if (InputManager.Instance.KeyBoard.KeyDown(Keys.Up))
                    player.Position.Y -= speed;
                if (InputManager.Instance.KeyBoard.KeyDown(Keys.Down))
                    player.Position.Y += speed;
            }

            player.Position = new Vector2(MathHelper.Clamp(player.Position.X, 0, GameSettings.TargetScreenWidth - player.Dimension.X),
                MathHelper.Clamp(player.Position.Y, 0, GameSettings.TargetScreenHeight - player.Dimension.Y));
        }

        public void FireWeapon(GameTime gameTime, Image player, IWeapon weapon)
        {
            int maxAction = 1;
            int action = 0;
            weapon.RefreshCoolDown(gameTime);

            if (InputManager.Instance.EnableMouse)
            {
                if (InputManager.Instance.Mouse.ButtonDown(MouseButtons.Left))
                {
                    weapon.Fire(player.Position);
                    action++;
                }
            }
            if (action < maxAction && InputManager.Instance.EnableTouch)
            {
                if (InputManager.Instance.Touch.Touched())
                {
                    weapon.Fire(player.Position);
                    action++;
                }
            }
            if (action < maxAction && InputManager.Instance.EnableKeyBoard)
            {
                if (InputManager.Instance.KeyBoard.KeyDown(Keys.Space))
                {
                    weapon.Fire(player.Position);
                    action++;
                }
            }
        }
    }
}
