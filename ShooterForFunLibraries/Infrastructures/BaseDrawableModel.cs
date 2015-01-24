using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ShooterForFunLibraries
{
    public class BaseDrawableModel : IDisposable
    {
        public string Id { get; set; }
        public string Path { get; set; }
        public Vector2 Position;
        public Vector2 Dimension { get; set; }
        public float Alpha { get; set; }
        public float Rotation { get; set; }
        public float ScaleRatio { get; set; }
        public Vector2 Origin { get; set; }
        public int SortOrder { get; set; }
        public Rectangle TargetRect;

        protected Texture2D texture;

        private ContentManager content;

        public ContentManager Content { 
            get
            {
                if (content == null)
                    content = ScreenManager.Instance.Content;
                return content;
            }
        }

        public BaseDrawableModel()
        {
            Id = string.Empty;
            Path = string.Empty;
            Position = Vector2.Zero;
            Dimension = Vector2.Zero;
            Alpha = 1.0f;
            ScaleRatio = 1.0f;
            Rotation = 0.0f;
            Origin = Vector2.Zero;
            SortOrder = 1;
        }

        public virtual void PreDraw(SpriteBatch spriteBatch)
        {
        }

        protected void GetTargetRect()
        {
            TargetRect.X = (int)Position.X;
            TargetRect.Y = (int)Position.Y;
            if (Dimension == Vector2.Zero)
            {
                TargetRect.Width = texture.Width;
                TargetRect.Height = texture.Height;
            }
            else
            {
                TargetRect.Width = (int)Dimension.X;
                TargetRect.Height = (int)Dimension.Y;
            }
        }

        public void Dispose()
        {
            //this.Dispose();
        }
    }
}
