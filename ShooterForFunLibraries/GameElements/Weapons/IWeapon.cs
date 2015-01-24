using Microsoft.Xna.Framework;

namespace ShooterForFunLibraries.Weapons
{
    public interface IWeapon
    {
        BulletSource BulletSource { get; set; }
        Vector2 OffsetPosition { get; set; }
        float FireRate { get; set; }
        void RefreshCoolDown(GameTime gameTime);
        void Fire(Vector2 position);
        void UnLoadContent();
    }
}
