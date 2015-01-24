using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShooterForFunLibraries.Graphics
{
    public class Image : BaseDrawableModel, IDrawableModel
    {
        public class Animation
        {

            public int FrameWidth { get; set; }
            public int FrameHeight { get; set; }
            public int TotalFrames { get; set; }
            public int FramesPerRow { get; set; }
            public int FramesPerColumn { get; set; }
            public int Speed { get; set; }
            public bool IsActive { get; set; }
            public bool IsLooping { get; set; }

            public Animation()
            {
                this.FrameWidth = 0;
                this.FrameHeight = 0;
                this.TotalFrames = 1;
                this.FramesPerRow = 1;
                this.FramesPerColumn = 1;
                this.Speed = 1;
                this.IsActive = false;
                this.IsLooping = false;
            }
        }

        public Rectangle? SourceRect { get; set; }
        public Animation Animations { get; set; }

        private int elapsedTime, currentFrame, currentCol, currentRow;

        public Image()
            : base()
        {
            elapsedTime = 0;
            currentFrame = 0;
            currentCol = 0;
            currentRow = 0;
            Animations = new Animation();
        }

        public void LoadContent()
        {
            texture = Content.Load<Texture2D>(string.IsNullOrEmpty(Path) ? GameSettings.DefaultImagePath : Path);
            if (Animations.FrameWidth == 0 || Animations.FrameHeight == 0)
            {
                Animations.FrameWidth = texture.Width / Animations.FramesPerColumn;
                Animations.FrameHeight = texture.Height / Animations.FramesPerRow;
            }
            GetTargetRect();        
        }

        public void UnLoadContent()
        {
            Dispose();
        }

        public void Update(GameTime gameTime)
        {
            GetTargetRect();        
            if (Animations.IsActive)
            {
                elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (elapsedTime > Animations.Speed)
                {
                    currentFrame++;
                    currentCol++;

                    if (currentCol == Animations.FramesPerColumn)
                    {
                        currentCol = 0;
                        currentRow++;
                    }                    

                    if (currentFrame == Animations.TotalFrames)
                    {
                        currentFrame = 0;
                        currentRow = 0;
                        currentCol = 0;
                        if (!Animations.IsLooping)
                            Animations.IsActive = false;
                    }

                    elapsedTime = 0;
                }

                SourceRect = new Rectangle(currentCol * Animations.FrameWidth, currentRow * Animations.FrameHeight, Animations.FrameWidth, Animations.FrameHeight);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, TargetRect, SourceRect, Color.White, Rotation, Origin, SpriteEffects.None, 0.0f);
        }

        public Image Clone()
        {
            return new Image()
            {
                Id = this.Id,
                Path = this.Path,
                Position = new Vector2(Position.X, Position.Y),
                Dimension = new Vector2(Dimension.X, Dimension.Y),
                Alpha = this.Alpha,
                Rotation = this.Rotation,
                ScaleRatio = this.ScaleRatio,
                Origin = new Vector2(Origin.X, Origin.Y),
                SortOrder = this.SortOrder,
                TargetRect = new Rectangle(TargetRect.X, TargetRect.Y, TargetRect.Width, TargetRect.Height),
                Animations = new Animation()
                {
                    FrameWidth = Animations.FrameWidth,
                    FrameHeight = Animations.FrameHeight,
                    TotalFrames = Animations.TotalFrames,
                    FramesPerRow = Animations.FramesPerRow,
                    FramesPerColumn = Animations.FramesPerColumn,
                    Speed = Animations.Speed,
                    IsActive = Animations.IsActive,
                    IsLooping = Animations.IsLooping
                }
            };
        }
    }
}
