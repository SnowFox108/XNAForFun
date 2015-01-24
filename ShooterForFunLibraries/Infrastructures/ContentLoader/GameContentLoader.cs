using Microsoft.Xna.Framework;
using ShooterForFunLibraries.Graphics;
using ShooterForFunLibraries.Sounds;
using System.Collections.Generic;

namespace ShooterForFunLibraries
{
    public class GameContentLoader
    {
        internal class ContentName
        {
            // Images
            internal const string imgPlayer = "Player";
            internal const string imgEnemyBallon = "Ballon";
            internal const string imgBulletLaser = "Laser";
            internal const string imgExplosion = "Explosion";

            // Sounds
            internal const string sndLaserFire = "LaserFire";
            internal const string sndExplosion = "Explosion";
        }

        private const string playerPath = "Data.GameSystem.Player.xml";
        private const string enemyPath = "Data.GameSystem.Enemies.xml";
        private const string weaponPath = "Data.GameSystem.Weapons.xml";
        private const string soundPath = "Data.GameSystem.Sounds.xml";

        private List<Image> players;
        private List<Image> enemies;
        private List<Image> bullets;
        private List<Sound> sounds;

        public GameContentLoader()
        {
            ContentLoader contentLoader = new ContentLoader();
            players = contentLoader.LoadImages(playerPath);
            enemies = contentLoader.LoadImages(enemyPath);
            bullets = contentLoader.LoadImages(weaponPath);
            sounds = contentLoader.LoadSounds(soundPath);
        }

        public Image GetPlayer()
        {
            return players.Find(i => i.Id == ContentName.imgPlayer);
        }

        public Image CreateEnemyBallon()
        {
            return enemies.Find(i => i.Id == ContentName.imgEnemyBallon).Clone();
        }

        public Image CreateBulletLaser()
        {
            return bullets.Find(i => i.Id == ContentName.imgBulletLaser).Clone();
        }

        public Image CreateExplosion()
        {
            return enemies.Find(i => i.Id == ContentName.imgExplosion).Clone();
        }

        public Sound GetLaserFire()
        {
            return sounds.Find(s => s.Id == ContentName.sndLaserFire);
        }

        public Sound GetExplosion()
        {
            return sounds.Find(s => s.Id == ContentName.sndExplosion);
        }

        public Shape GetPlayerLifeBar()
        {
            return new Shape()
            {
                Id = "PlayerLifeBar"
            };
        }

        public TextMessage GetScoreText()
        {
            return new TextMessage()
            {
                Id = "Scores",
                Path = "Fonts/Tahoma",
                Text = "Total Scores: 0",
                Position = new Vector2(600, 10)
            };

        }

    }
}
