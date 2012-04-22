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

        public override void Capture()
        {
            LastState = CurrentState;
            CurrentState = Keyboard.GetState();
        }
    }
}