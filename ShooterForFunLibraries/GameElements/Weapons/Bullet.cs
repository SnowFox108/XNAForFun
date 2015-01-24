using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterForFunLibraries.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShooterForFunLibraries.Movements;

namespace ShooterForFunLibraries.Weapons
{
    public enum BulletSource
    {
        Player,
        Computer
    }

    public class Bullet: IDrawableModel
    {
        public BulletSource BulletSource { get; set; }
        public float Damage { get; set; }
        public IMovement Movement { get; set; }
        public Func<Image> ImageLoader { get; set; }
        public bool IsDestroyed { get; set; }
        public Rectangle ActualRect { get { return image.TargetRect; } }

        private Image image;

        public Bullet()
        {
            this.Damage = 0.0f;
            this.IsDestroyed = false;
        }

        public void LoadContent()
        {
            image = ImageLoader();
            image.Position = Movement.StartPoition;
            image.LoadContent();
        }

        public void UnLoadContent()
        {
            image.UnLoadContent();
        }

        public void Update(GameTime gameTime)
        {
            Movement.Move(gameTime, image);
           if (Movement.LogicMove(gameTime, image))
                IsDestroyed = true;
            else
                image.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            image.Draw(spriteBatch);
        }
    }
}
