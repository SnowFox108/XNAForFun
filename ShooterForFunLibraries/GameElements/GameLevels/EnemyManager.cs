using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShooterForFunLibraries.GameLevels
{
    public class EnemyManager : IDrawableModel
    {
        private static EnemyManager instance;
        public static EnemyManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new EnemyManager();
                return instance;
            }
        }

        private List<Ballon> enemies;
        public List<Ballon> Enemies { get { return enemies; } }

        public EnemyManager()
        {
            enemies = new List<Ballon>();
        }

        public void CreateEnemy(Ballon ballon)
        {
            ballon.LoadContent();
            enemies.Add(ballon);
        }

        public bool CheckForHitPlayer(Player player)
        {
            if (player.IsDestroying || player.IsDestroyed)
                return false;
            foreach (var item in enemies.Where(e => e.IsDestroying == false && e.IsDestroyed == false))
            {
                if (item.ActualRect.Intersects(player.ActualRect))
                {
                    player.Hit(item.Health);
                    item.Hit(player.Health);
                    return true;
                }
            }
            return false;

        }

        public void LoadContent()
        {
            foreach (var item in enemies)
                item.LoadContent();
        }

        public void UnLoadContent()
        {
            foreach (var item in enemies)
                item.UnLoadContent();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in enemies)
                item.Update(gameTime);
            foreach (var item in enemies.Where(e => e.IsDestroyed).ToList())
            {
                enemies.Remove(item);
                item.UnLoadContent();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in enemies)
                item.Draw(spriteBatch);
        }
    }
}
