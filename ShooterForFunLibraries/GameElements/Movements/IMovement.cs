using Microsoft.Xna.Framework;
using ShooterForFunLibraries.Graphics;

namespace ShooterForFunLibraries.Movements
{
    public enum MoveDirection
    {
        None,
        Top,
        TopRight,
        Right,
        DownRight,
        Down,
        DownLeft,
        Left,
        TopLeft,
        FreeAngle,
        Target
    }

    public interface IMovement
    {
        float Speed { get; set; }
        float Angle { get; set; }
        Vector2 StartPoition { get; set; }
        Vector2 TargetPosition { get; set; }
        MoveDirection Direction { get; set; }
        float CurrentStep { get; set; }
        float MaxStep { get; set; }

        void Move(GameTime gameTime, Image image);
        bool LogicMove(GameTime gameTime, Image image);
    }
}
