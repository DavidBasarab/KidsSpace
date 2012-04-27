using Microsoft.Xna.Framework.Input;

namespace Common.Game.Controls
{
    public class KeyboardStateManager : BaseStateManager
    {
        private static KeyboardStateManager _instance;

        public static KeyboardStateManager KeyboardState
        {
            get { return _instance ?? (_instance = new KeyboardStateManager()); }
        }

        private KeyboardStateManager() {}

        public KeyboardState LastState { get; set; }
        public KeyboardState CurrentState { get; set; }

        public bool IsWDown
        {
            get { return IsKeyDown(Keys.W); }
        }

        public bool IsSDown
        {
            get { return IsKeyDown(Keys.S); }
        }

        public bool IsADown
        {
            get { return IsKeyDown(Keys.A); }
        }

        public bool IsDDown
        {
            get { return IsKeyDown(Keys.D); }
        }

        public bool IsSpaceDown
        {
            get { return IsKeyDown(Keys.Space); }
        }

        public override void Capture()
        {
            LastState = CurrentState;
            CurrentState = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
        {
            return CurrentState.IsKeyDown(key);
        }
    }
}