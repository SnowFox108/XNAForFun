using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace ShooterForFunLibraries.Weapons
{
    public class BulletManager : IDrawableModel
    {
        private static BulletManager instance;
        public static BulletManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new BulletManager();
                return instance;
            }
        }
        private List<Bullet> bullets;
        public List<Bullet> Bullets { get { return bullets; } }

        public BulletManager()
        {
            bullets = new List<Bullet>();
        }

        public void Fire(Bullet bullet)
        {
            bullet.LoadContent();
            bullets.Add(bullet);
        }

        public bool CheckForHitComputer(Ballon ballon)
        {
            if (ballon.IsDestroying || ballon.IsDestroyed)
                return false;

            foreach (var item in bullets.Where(b => b.BulletSource == BulletSource.Player))
            {
                if (item.ActualRect.Intersects(ballon.ActualRect))
                {
                    ballon.Hit(item.Damage);
                    item.IsDestroyed = true;
                    return true;
                }
            }
            return false;
        }

        public bool CheckForHitPlayer(Player player)
        {
            if (player.IsDestroying || player.IsDestroyed)
                return false;
            foreach (var item in bullets.Where(b => b.BulletSource == BulletSource.Computer))
            {
                if (item.ActualRect.Intersects(player.ActualRect))
                {
                    player.Hit(item.Damage);
                    item.IsDestroyed = true;
                    return true;
                }
            }
            return false;
        }

        public void LoadContent()
        {
            foreach (var item in bullets)
                item.LoadContent();
        }

        public void UnLoadContent()
        {
            foreach (var item in bullets)
                item.UnLoadContent();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in bullets)
                item.Update(gameTime);
            foreach (var item in bullets.Where(b => b.IsDestroyed).ToList())
            {
                bullets.Remove(item);
                item.UnLoadContent();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in bullets)
                item.Draw(spriteBatch);
        }
    }
}
