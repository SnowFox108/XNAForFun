using Microsoft.Xna.Framework;
using ShooterForFunLibraries.Graphics;
using ShooterForFunLibraries.Movements;
using ShooterForFunLibraries.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Weapons
{
    public class LaserGun : IWeapon
    {
        private BulletSource bulletSource;
        public BulletSource BulletSource
        {
            get { return bulletSource; }
            set { bulletSource = value; }
        }

        public Vector2 OffsetPosition { get; set; }
        public float FireRate {
            get { return fireRate; }
            set { fireRate = value <= 0.0f ? 1.0f : 1.0f/value; }
        }

        private GameContentLoader contentLoader;
        private float elapsedTime, fireRate;
        private Sound fireSound;

        public LaserGun(BulletSource bulletSource)
        {
            contentLoader = new GameContentLoader();
            this.bulletSource = bulletSource;
            this.FireRate = 1.0f;
            fireSound = contentLoader.GetLaserFire();
            fireSound.LoadContent();
        }

        public void RefreshCoolDown(GameTime gameTime)
        {
            elapsedTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedTime <= 0)
                elapsedTime = 0;
        }

        public void Fire(Vector2 position)
        {
            if (elapsedTime <= 0)
            {
                switch (bulletSource)
                {
                    case BulletSource.Player:
                        BulletManager.Instance.Fire(new Bullet()
                            {
                                BulletSource = bulletSource,
                                Damage = 5.0f,
                                ImageLoader = contentLoader.CreateBulletLaser,
                                Movement = new BaseMovement()
                                {
                                    Speed = 20,
                                    StartPoition = position + OffsetPosition,
                                    Direction = MoveDirection.Right,
                                    CurrentStep = position.X + OffsetPosition.X,
                                    MaxStep = GameSettings.TargetScreenWidth
                                }
                            });
                        SoundManager.Instance.Play(fireSound);
                        break;
                    case BulletSource.Computer:
                        BulletManager.Instance.Fire(new Bullet()
                        {
                            BulletSource = bulletSource,
                            Damage = 5.0f,
                            ImageLoader = contentLoader.CreateBulletLaser,
                            Movement = new BaseMovement()
                            {
                                Speed = 10,
                                StartPoition = position + OffsetPosition,
                                Direction = MoveDirection.Left,
                                CurrentStep = position.X + OffsetPosition.X,
                                MaxStep = 0
                            }
                        });
                        SoundManager.Instance.Play(fireSound);
                        break;
                }
                elapsedTime = fireRate;
            }
        }

        public void UnLoadContent()
        {
            fireSound.UnloadContent();
        }
    }
}
