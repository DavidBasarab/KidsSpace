using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Common.Game.Controls
{
    public class MouseStateManager : BaseStateManager
    {
        private static MouseStateManager _instance;

        public static MouseStateManager MouseState
        {
            get { return _instance ?? (_instance = new MouseStateManager()); }
        }

        private MouseStateManager()
        {
            Capture();
        }

        private MouseState CurrentState { get; set; }
        private MouseState LastState { get; set; }

        public bool IsLeftButtonPressed
        {
            get { return CurrentState.LeftButton == ButtonState.Pressed; }
        }

        public float DeltaX
        {
            get { return LastState.X - (float)CurrentState.X; }
        }

        public float DeltaY
        {
            get { return LastState.Y - (float)CurrentState.Y; }
        }

        public float ScrollDelta
        {
            get { return (float)LastState.ScrollWheelValue - CurrentState.ScrollWheelValue; }
        }

        public override void Capture()
        {
            LastState = CurrentState;

            CurrentState = Mouse.GetState();
        }

        public bool MouseInRectangle(Rectangle rectangle)
        {
            return rectangle.Contains(CurrentState.X, CurrentState.Y);
        }
    }
}