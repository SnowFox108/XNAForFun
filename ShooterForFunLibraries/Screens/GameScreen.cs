using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterForFunLibraries.GameLevels;
using ShooterForFunLibraries.Graphics;
using ShooterForFunLibraries.Inputs;
using ShooterForFunLibraries.Sounds;
using ShooterForFunLibraries.Weapons;
using System;
using System.Collections.Generic;

namespace ShooterForFunLibraries
{
    public class GameScreen : BaseDrawableModel, IScreen
    {
        private GameScreenLoader screenLoader;
        private GameScreenAction screenAction;

        private List<IDrawableModel> backGroundLayer = new List<IDrawableModel>();
        private List<IDrawableModel> gameLayer = new List<IDrawableModel>();
        private List<IDrawableModel> foreGroundLayer = new List<IDrawableModel>();

        private Button btnReturn;
        private Player player;
        private Music bgMusic;

        private IGameLevel gameLevel;

        public event EventHandler OnGameFinish;

        public GameScreen()
        {
            screenLoader = new GameScreenLoader();
            screenAction = new GameScreenAction();

            InputManager.Instance.EnableMouse = true;
            InputManager.Instance.EnableTouch = true;
            InputManager.Instance.EnableKeyBoard = true;

            BulletManager.Instance.Bullets.Clear();
            EnemyManager.Instance.Enemies.Clear();
            backGroundLayer.Clear();
            gameLayer.Clear();
            foreGroundLayer.Clear();

            player = new Player(new Vector2(200, 450));
            player.OnDead += player_OnDead;
            gameLayer.Add(player);
            gameLayer.Add(BulletManager.Instance);

            gameLevel = new Level1();
            gameLayer.Add(EnemyManager.Instance);

            FPSdisplay fps = screenLoader.GetFPSDisplay();
            foreGroundLayer.Add(fps);

            ScoreManager.Instance.ResetScore();
            foreGroundLayer.Add(ScoreManager.Instance);

            TextMessage text = screenLoader.GetGameText();
            text.Text = "This is Game Screen";
            text.Position = new Vector2(800, 600);
            foreGroundLayer.Add(text);

            btnReturn = new Button();
            btnReturn.Text = screenLoader.CreateStartButtonText();
            btnReturn.Text.Text = "Return to Menu";
            btnReturn.Background = screenLoader.CreateMenuButton();
            btnReturn.Background.Dimension = Vector2.Zero;
            btnReturn.Background.FillColor = Color.DarkGoldenrod;
            btnReturn.Text_Align = TextAlign.Left;
            btnReturn.Text_Valign = TextValign.Middle;
            btnReturn.Position = new Vector2(1400, 0);
            btnReturn.Padding = 5;
            btnReturn.OnClick += btnReturn_OnClick;
            foreGroundLayer.Add(btnReturn);

            bgMusic = screenLoader.GetBackGroundMusic();

        }

        void player_OnDead(object sender, EventArgs e)
        {
            OnGameFinish(this, new EventArgs());
        }

        void btnReturn_OnClick(object sender, System.EventArgs e)
        {
            OnGameFinish(this, new EventArgs());
        }

        public void LoadContent()
        {
            bgMusic.LoadContent();
            SoundManager.Instance.Play(bgMusic);

            foreach (var item in backGroundLayer)
                item.LoadContent();
            foreach (var item in gameLayer)
                item.LoadContent();
            foreach (var item in foreGroundLayer)
                item.LoadContent();
        }

        public void UnLoadContent()
        {
            SoundManager.Instance.Stop(bgMusic);
            //foreach (var item in backGroundLayer)
            //    item.UnLoadContent();
            //foreach (var item in gameLayer)
            //    item.UnLoadContent();
            //foreach (var item in foreGroundLayer)
            //    item.UnLoadContent();
        }

        public void Update(GameTime gameTime)
        {
            InputManager.Instance.Update();
            gameLevel.Update(gameTime);
            screenAction.MenuAction(btnReturn);
            foreach (var item in backGroundLayer)
                item.Update(gameTime);
            foreach (var item in gameLayer)
                item.Update(gameTime);
            foreach (var item in foreGroundLayer)
                item.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in backGroundLayer)
                item.Draw(spriteBatch);
            foreach (var item in gameLayer)
                item.Draw(spriteBatch);
            foreach (var item in foreGroundLayer)
                item.Draw(spriteBatch);
        }

    }
}
