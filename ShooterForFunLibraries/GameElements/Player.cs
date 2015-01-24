using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterForFunLibraries.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShooterForFunLibraries.Weapons;
using ShooterForFunLibraries.GameLevels;

namespace ShooterForFunLibraries
{
    public class Player: IDrawableModel
    {

        public float Health { get; set; }
        public IWeapon Weapon { get; set; }
        public bool IsDestroying { get; set; }
        public bool IsDestroyed { get; set; }
        public Rectangle ActualRect { get { return image.TargetRect; } }

        public event EventHandler OnDead;

        private GameContentLoader gameLoader = new GameContentLoader();
        private float moveSpeed = 8;
        private float maxHealth = 100;
        private Image image;
        private Shape lifeBar;
        private Vector2 lifeBarOffSet;
        private PlayerAction playerAction = new PlayerAction();

        public Player (Vector2 position)
        {
            image = gameLoader.GetPlayer();
            image.Position = position;
            lifeBar = gameLoader.GetPlayerLifeBar();
            lifeBarOffSet = new Vector2(0, -8);

            this.Health = maxHealth;

            Weapon = new LaserGun(BulletSource.Player)
            {
                FireRate = 5.0f,
                OffsetPosition = new Vector2(image.Dimension.X - 40, image.Dimension.Y / 2 -10)
            };
        }

        public void Hit(float damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Image currentImage = image;
                IsDestroying = true;
                image = gameLoader.CreateExplosion();
                image.LoadContent();
                image.Position = currentImage.Position + (image.Dimension - currentImage.Dimension) / 2;
                currentImage.UnLoadContent();
            }
        }

        public void LoadContent()
        {
            image.LoadContent();
            lifeBar.LoadContent();
        }

        public void UnLoadContent()
        {
            image.UnLoadContent();
            lifeBar.UnLoadContent();
            Weapon.UnLoadContent();
        }

        public void Update(GameTime gameTime)
        {
            BulletManager.Instance.CheckForHitPlayer(this);
            EnemyManager.Instance.CheckForHitPlayer(this);
            playerAction.PlayerMove(image, moveSpeed);
            playerAction.FireWeapon(gameTime, image, Weapon);

            #region LifeBar

            lifeBar.Position = image.Position + lifeBarOffSet;
            lifeBar.Dimension = new Vector2((image.Dimension.X / maxHealth) * Health, 5);
            if (Health >= 50)
                lifeBar.FillColor = Color.Green;
            else if (Health < 50 && Health > 10)
                lifeBar.FillColor = Color.Yellow;
            else
                lifeBar.FillColor = Color.Red;
            lifeBar.Update(gameTime);

            #endregion

            if (IsDestroying && !image.Animations.IsActive)
                OnDead(this, new EventArgs());
            image.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            image.Draw(spriteBatch);
            lifeBar.Draw(spriteBatch);
        }
    }
}
