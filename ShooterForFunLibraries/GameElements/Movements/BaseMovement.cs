using Microsoft.Xna.Framework;
using ShooterForFunLibraries.Graphics;

namespace ShooterForFunLibraries.Movements
{
    public class BaseMovement : IMovement
    {
        public float Speed { get; set; }
        public float Angle { get; set; }
        public Vector2 StartPoition { get; set; }
        public Vector2 TargetPosition { get; set; }
        private MoveDirection direction;
        public MoveDirection Direction
        {
            get { return direction; }
            set
            {
                direction = value;
                ResetMovement();
            }
        }
        public float CurrentStep { get; set; }
        public float MaxStep { get; set; }
        protected Vector2 positionOffSet;

        public BaseMovement()
        {
            this.Speed = 0.0f;
            this.Angle = 0.0f;
            this.StartPoition = Vector2.Zero;
            this.TargetPosition = Vector2.Zero;
            this.Direction = MoveDirection.None;
            this.CurrentStep = 0.0f;
            this.MaxStep = 0.0f;
            positionOffSet = Vector2.Zero;
        }

        protected virtual void ResetMovement()
        {
            switch(direction)
            {
                case MoveDirection.None:
                    positionOffSet = Vector2.Zero;
                    break;
                case MoveDirection.Top:
                    positionOffSet = new Vector2(0, -Speed);
                    break;
                case MoveDirection.TopRight:
                    positionOffSet = new Vector2(Speed, -Speed);
                    break;
                case MoveDirection.Right:
                    positionOffSet = new Vector2(Speed, 0);
                    break;
                case MoveDirection.DownRight:
                    positionOffSet = new Vector2(Speed, Speed);
                    break;
                case MoveDirection.Down:
                    positionOffSet = new Vector2(0, Speed);
                    break;
                case MoveDirection.DownLeft:
                    positionOffSet = new Vector2(-Speed, Speed);
                    break;
                case MoveDirection.Left:
                    positionOffSet = new Vector2(-Speed, 0);
                    break;                    
            }
        }

        public virtual void Move(GameTime gameTime, Image image)
        {
            image.Position += positionOffSet;
        }


        public bool LogicMove(GameTime gameTime, Image image)
        {
            CurrentStep += positionOffSet.X;
            switch (direction)
            {
                case MoveDirection.Right:
                    return (CurrentStep > MaxStep);
                case MoveDirection.Left:
                    return (CurrentStep < MaxStep);
            }
            return false;
        }
    }
}
