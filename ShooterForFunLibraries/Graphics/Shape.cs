using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Graphics
{
    public class Shape : BaseDrawableModel, IDrawableModel
    {

        public Color FillColor { get; set; }

        public Shape() : base() 
        {
            FillColor = Color.White;
        }

        public void LoadContent()
        {
            texture = new Texture2D(ScreenManager.Instance.GraphicDevice, 1, 1);
        }

        public void UnLoadContent()
        {
            Dispose();
        }

        public void Update(GameTime gameTime)
        {
            GetTargetRect();
            texture.SetData(new Color[] { FillColor });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, TargetRect, null, Color.White, Rotation, Origin, SpriteEffects.None, 0.0f);
        }

        public Shape Clone()
        {
            return new Shape()
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
                FillColor = this.FillColor
            };
        }
    }
}
