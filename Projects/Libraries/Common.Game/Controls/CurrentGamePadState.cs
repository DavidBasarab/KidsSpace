using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Common.Game.Controls
{
    public class CurrentGamePadState
    {
        private static CurrentGamePadState _playerOneInstance;

        public static CurrentGamePadState PlayerOne
        {
            get { return _playerOneInstance ?? (_playerOneInstance = new CurrentGamePadState(PlayerIndex.One)); }
        }

        private CurrentGamePadState(PlayerIndex playerIndex)
        {
            Index = playerIndex;
        }

        private PlayerIndex Index { get; set; }

        public bool IsBackButtonPressed
        {
            get { return GamePadState.Buttons.Back == ButtonState.Pressed; }
        }

        private GamePadState GamePadState
        {
            get { return GamePad.GetState(Index); }
        }
    }
}