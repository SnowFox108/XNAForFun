using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterForFunLibraries.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries
{
    public class ScoreManager : IDrawableModel
    {
        private static ScoreManager instance;
        public static ScoreManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScoreManager();
                return instance;
            }
        }

        private int score;
        private TextMessage textMessage;
        private GameContentLoader gameLoader;

        public ScoreManager()
        {
            gameLoader = new GameContentLoader();
            textMessage = gameLoader.GetScoreText();
        }

        public void ResetScore()
        {
            score = 0;
        }

        public void AddScore(int point)
        {
            score += point;
        }

        public void LoadContent()
        {
            textMessage.LoadContent();
        }

        public void UnLoadContent()
        {
            textMessage.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            textMessage.Text = string.Format("Total Scores: {0}", score);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            textMessage.Draw(spriteBatch);
        }
    }
}
