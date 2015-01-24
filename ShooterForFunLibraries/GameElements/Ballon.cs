using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterForFunLibraries.Graphics;
using ShooterForFunLibraries.Intelligents;
using ShooterForFunLibraries.Movements;
using ShooterForFunLibraries.Sounds;
using ShooterForFunLibraries.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries
{
    public class Ballon : IDrawableModel
    {
        public float Health { get; set; }
        public IWeapon Weapon { get; set; }
        public bool IsDestroyed { get; set; }
        public bool IsDestroying { get; set; }
        public IMovement Movement { get; set; }
        public IFireLogic FireLogic { get; set; }
        public Rectangle ActualRect { get { return image.TargetRect; } }

        private GameContentLoader gameLoader = new GameContentLoader();
        private Image image;
        private Sound explosion;

        public Ballon(Vector2 position)
        {
            image = gameLoader.CreateEnemyBallon();            
            image.Position = position;

            this.Health = 5;

            Weapon = new LaserGun(BulletSource.Computer)
            {
                FireRate = 0.5f,
                OffsetPosition = new Vector2(0, image.Dimension.Y / 2)
            };

            Movement = new BaseMovement()
            {
                Speed = 2.0f,
                CurrentStep = position.X,
                MaxStep = 0,
                Direction = MoveDirection.Left
            };

            FireLogic = new SimpleFireLogic();

            explosion = gameLoader.GetExplosion();
            explosion.LoadContent();
        }

        public void Hit(float damage)
        {
            if (IsDestroying == false && IsDestroyed == false)
            {
                Health -= damage;
                if (Health <= 0)
                {
                    Image currentImage = image;
                    IsDestroying = true;
                    image = gameLoader.CreateExplosion();
                    image.LoadContent();
                    image.Position = currentImage.Position - (image.Dimension - currentImage.Dimension) / 2;
                    currentImage.UnLoadContent();
                    Movement.Speed = 0.0f;
                    SoundManager.Instance.Play(explosion);
                    ScoreManager.Instance.AddScore(100);
                }
            }
        }

        public void LoadContent()
        {
            image.LoadContent();
        }

        public void UnLoadContent()
        {
            image.UnLoadContent();
            explosion.UnloadContent();
            Weapon.UnLoadContent();
        }

        public void Update(GameTime gameTime)
        {
            BulletManager.Instance.CheckForHitComputer(this);
            Movement.Move(gameTime, image);
            FireLogic.Fire(gameTime, image.Position, Weapon);
            if (Movement.LogicMove(gameTime, image) || (IsDestroying && !image.Animations.IsActive))
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
