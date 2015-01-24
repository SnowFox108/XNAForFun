using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using ShooterForFunLibraries;

namespace ShooterForFunWP8
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class ShooterGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private int screenHeight, screenWidth;

        private RenderTarget2D _renderTarget;

        public ShooterGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screenHeight = _graphics.GraphicsDevice.Viewport.Width;
            screenWidth = _graphics.GraphicsDevice.Viewport.Height;
            GameSettings.ScreenScaleRatio = ((float)screenWidth / (float)GameSettings.TargetScreenWidth) < ((float)screenHeight / (float)GameSettings.TargetScreenHeight) ? 
                (float)screenWidth / (float)GameSettings.TargetScreenWidth : (float)screenHeight / (float)GameSettings.TargetScreenHeight;

            _graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.ScreenSize.X;
            _graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.ScreenSize.Y;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ScreenManager.Instance.GraphicDevice = GraphicsDevice;
            ScreenManager.Instance.LoadContent(Content);

            // Set up the Screen size
            _renderTarget = new RenderTarget2D(GraphicsDevice, GameSettings.TargetScreenWidth, GameSettings.TargetScreenHeight);
            GameSettings.ScreenOffSetX = (screenWidth - _renderTarget.Width * GameSettings.ScreenScaleRatio) / 2;
            GameSettings.ScreenOffSetY = (screenHeight - _renderTarget.Height * GameSettings.ScreenScaleRatio) / 2;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            ScreenManager.Instance.UnLoadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            ScreenManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            ScreenManager.Instance.Draw(_spriteBatch);
            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            if (GameSettings.PhoneScreenOrientation == PhoneOrientations.LandscpeFlipped)
                _spriteBatch.Draw(_renderTarget, new Vector2(GameSettings.ScreenOffSetY, screenWidth - GameSettings.ScreenOffSetX),
                    null, Color.White, MathHelper.Pi + MathHelper.PiOver2, Vector2.Zero, GameSettings.ScreenScaleRatio, SpriteEffects.None, 0f);
            else
                _spriteBatch.Draw(_renderTarget, new Vector2(screenHeight - GameSettings.ScreenOffSetY, GameSettings.ScreenOffSetX),
                    null, Color.White, MathHelper.PiOver2, Vector2.Zero, GameSettings.ScreenScaleRatio, SpriteEffects.None, 0f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
