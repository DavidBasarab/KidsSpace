using Common.Game;
using Common.Game.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FloodControl
{
    public class FloodControlGame : BaseGame
    {
        private Texture2D BackgroundScreen { get; set; }
        private Texture2D PlayingPieces { get; set; }
        private Texture2D TitleScreen { get; set; }

        private static CurrentGamePadState Player
        {
            get { return CurrentGamePadState.PlayerOne; }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            CreateNewSpriteBachToDrawTextures();
        }

        protected override void UnloadContent() {}

        protected override void Update(GameTime gameTime)
        {
            if (Player.IsBackButtonPressed) Exit();

            base.Update(gameTime);
        }
    }
}