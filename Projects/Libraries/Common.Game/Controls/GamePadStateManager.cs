using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Common.Game.Controls
{
    public class GamePadStateManager : BaseStateManager
    {
        private static GamePadStateManager _playerOneInstance;

        public static GamePadStateManager PlayerOne
        {
            get { return _playerOneInstance ?? (_playerOneInstance = new GamePadStateManager(PlayerIndex.One)); }
        }

        private GamePadStateManager(PlayerIndex playerIndex)
        {
            Index = playerIndex;
        }

        private PlayerIndex Index { get; set; }

        public bool IsBackButtonPressed
        {
            get { return CurrentState.Buttons.Back == ButtonState.Pressed; }
        }

        private GamePadState LastState { get; set; }
        private GamePadState CurrentState { get; set; }

        public override void Capture()
        {
            LastState = CurrentState;
            CurrentState = GamePad.GetState(Index);
        }
    }
}