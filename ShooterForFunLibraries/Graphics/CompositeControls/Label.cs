using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Graphics
{
    public class Label : BaseDrawableModel, IDrawableModel
    {
        public TextMessage Text { get; set; }
        public Shape Background { get; set; }
        public TextAlign Text_Align { get; set; }
        public TextValign Text_Valign { get; set; }
        public float Padding { get; set; }


        public Label()
        {
            Text_Align = TextAlign.Centre;
            Text_Valign = TextValign.Middle;
            Padding = 0.0f;
        }


        public void LoadContent()
        {
            Text.LoadContent();
            Background.LoadContent();

            if (Background.Dimension == Vector2.Zero)
                Background.Dimension = new Vector2(Text.TextStringWidth, Text.TextStringHeight) + new Vector2(Padding * 2, Padding * 2);

            if (Dimension == Vector2.Zero)
                Dimension = Background.Dimension;
            else
                Background.Dimension = Dimension;
        }

        public void UnLoadContent()
        {
            Text.Dispose();
            Background.Dispose();
        }

        public virtual void Update(GameTime gameTime)
        {
            Background.Position = this.Position;

            Vector2 textPosition = Position;

            switch (Text_Align)
            {
                case TextAlign.Left:
                    textPosition.X = Position.X + Padding;
                    break;
                case TextAlign.Centre:
                    textPosition.X = Position.X + (Background.Dimension.X / 2) - (Text.TextStringWidth / 2);
                    break;
                case TextAlign.Right:
                    textPosition.X = Position.X + (Background.Dimension.X) - (Text.TextStringWidth) - Padding;
                    break;
            }

            switch (Text_Valign)
            {
                case TextValign.Top:
                    textPosition.Y = Position.Y + Padding;
                    break;
                case TextValign.Middle:
                    textPosition.Y = Position.Y + (Background.Dimension.Y / 2) - (Text.TextStringHeight / 2);
                    break;
                case TextValign.Bottom:
                    textPosition.Y = Position.Y + (Background.Dimension.Y) - (Text.TextStringHeight) - Padding;
                    break;
            }

            Text.Position = textPosition;

            Text.Update(gameTime);
            Background.Update(gameTime);
            GetTargetRect();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Background.Draw(spriteBatch);
            Text.Draw(spriteBatch);
        }
    }
}
