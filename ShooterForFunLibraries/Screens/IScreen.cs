using Microsoft.Xna.Framework.Graphics;

namespace ShooterForFunLibraries
{
    public interface IScreen : IDrawableModel
    {
        void PreDraw(SpriteBatch spriteBatch);
    }
}
