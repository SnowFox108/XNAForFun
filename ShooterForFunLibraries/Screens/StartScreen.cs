using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterForFunLibraries.Graphics;
using ShooterForFunLibraries.Inputs;
using ShooterForFunLibraries.Sounds;
using System;
using System.Collections.Generic;

namespace ShooterForFunLibraries
{
    public class StartScreen : BaseDrawableModel, IScreen
    {
        private StartScreenLoader screenLoader;
        private StartScreenAction screenAction;

        private Image backGround;
        private List<Button> buttons;
        private Music bgMusic;

        public event EventHandler OnGameStart;

        public StartScreen()
        {
            screenLoader = new StartScreenLoader();
            screenAction = new StartScreenAction();

            InputManager.Instance.EnableMouse = true;
            InputManager.Instance.EnableTouch = true;
            
            backGround = screenLoader.GetBackGround();

            buttons = new List<Button>();
            Button btnStart, btnOption;

            btnStart = new Button();
            btnStart.Text = screenLoader.CreateStartButtonText();
            btnStart.Background = screenLoader.CreateMenuButton();
            btnStart.Background.FillColor = Color.DarkGoldenrod;
            btnStart.Text_Align = TextAlign.Centre;
            btnStart.Text_Valign = TextValign.Middle;
            btnStart.Position = new Vector2(835, 500);
            btnStart.Dimension = new Vector2(300, 80);
            btnStart.OnClick += btnStart_OnClick;
            buttons.Add(btnStart);

            btnOption = new Button();
            btnOption.Text = screenLoader.CreateStartButtonText();
            btnOption.Background = screenLoader.CreateMenuButton();
            btnOption.Background.FillColor = Color.DarkGoldenrod;
            btnOption.Text.Text = "Options";
            btnOption.Text_Align = TextAlign.Centre;
            btnOption.Text_Valign = TextValign.Middle;
            btnOption.Position = new Vector2(835, 600);
            btnOption.Dimension = new Vector2(300, 80);
            buttons.Add(btnOption);

            bgMusic = screenLoader.GetBackGroundMusic();
        }

        void btnStart_OnClick(object sender, EventArgs e)
        {
            OnGameStart(this, new EventArgs());
        }

        public void LoadContent()
        {
            backGround.LoadContent();
            foreach (var item in buttons)
                item.LoadContent();
            bgMusic.LoadContent();
            SoundManager.Instance.Play(bgMusic);
        }

        public void UnLoadContent()
        {
            SoundManager.Instance.Stop(bgMusic);
            bgMusic.UnloadContent();
            backGround.UnLoadContent();
            foreach (var item in buttons)
                item.UnLoadContent();
            Dispose();
        }

        public void Update(GameTime gameTime)
        {
            InputManager.Instance.Update();
            backGround.Update(gameTime);
            foreach (var item in buttons)
            {
                screenAction.MenuAction(item);
                item.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            backGround.Draw(spriteBatch);
            foreach (var item in buttons)
                item.Draw(spriteBatch);

        }

    }
}
