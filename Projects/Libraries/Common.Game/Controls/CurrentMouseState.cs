using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Common.Game.Controls
{
    public class CurrentMouseState
    {
        private static CurrentMouseState _instance;

        public static CurrentMouseState MouseState
        {
            get { return _instance ?? (_instance = new CurrentMouseState()); }
        }

        private static MouseState State
        {
            get { return Mouse.GetState(); }
        }

        private CurrentMouseState() {}

        public bool IsLeftButtonPressed
        {
            get { return State.LeftButton == ButtonState.Pressed; }
        }

        public bool MouseInRectangle(Rectangle rectangle)
        {
            return rectangle.Contains(State.X, State.Y);
        }
    }
}