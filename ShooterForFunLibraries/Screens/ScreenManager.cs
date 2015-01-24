using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries
{
    public class ScreenManager
    {
        private static ScreenManager instance;

        public GraphicsDevice GraphicDevice { get; set; }
        public ContentManager Content { get; private set; }
        public Vector2 ScreenSize { get; private set; }

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        private IScreen currentScreen;

        public ScreenManager()
        {
            ScreenSize = new Vector2(GameSettings.TargetScreenWidth, GameSettings.TargetScreenHeight);
            currentScreen = new StartScreen();

            StartScreen startScreen = (StartScreen)currentScreen;
            startScreen.OnGameStart += startScreen_OnGameStart;
        }

        void startScreen_OnGameStart(object sender, EventArgs e)
        {
            currentScreen.UnLoadContent();
            Content.Unload();
            currentScreen = new GameScreen();
            GameScreen gameScreen = (GameScreen)currentScreen;
            gameScreen.OnGameFinish += gameScreen_OnGameFinish;
            currentScreen.LoadContent();
        }

        void gameScreen_OnGameFinish(object sender, EventArgs e)
        {
            currentScreen.UnLoadContent();
            Content.Unload();
            currentScreen = new StartScreen();
            StartScreen startScreen = (StartScreen)currentScreen;
            startScreen.OnGameStart += startScreen_OnGameStart;
            currentScreen.LoadContent();
        }

        public void LoadContent(ContentManager content)
        {
            this.Content = new ContentManager(content.ServiceProvider, "Content");
            currentScreen.LoadContent();
        }

        public void UnLoadContent()
        {
            currentScreen.UnLoadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        public void PreDraw(SpriteBatch spriteBatch)
        {
            currentScreen.PreDraw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);

        }
    }
}
