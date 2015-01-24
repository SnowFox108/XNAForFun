using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Graphics
{
    public class TextMessage : BaseDrawableModel, IDrawableModel
    {

        public string Text { get; set; }
        public Color FillColor { get; set; }

        public float TextStringWidth {
            get { return font.MeasureString(Text).X; }
        }
        public float TextStringHeight {
            get { return font.MeasureString(Text).Y; }
        }

        private SpriteFont font;

        public TextMessage() : base()
        {
            Text = string.Empty;
            FillColor = Color.White;
        }

        public void LoadContent()
        {
            font = Content.Load<SpriteFont>(Path);
        }

        public void UnLoadContent()
        {
            Dispose();
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, Text, Position, FillColor, Rotation, Origin, ScaleRatio, SpriteEffects.None, 0.0f);
        }

        public TextMessage Clone()
        {
            return new TextMessage
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
                Text = this.Text,
                FillColor = this.FillColor
            };
        }
    }
}
