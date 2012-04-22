using Common.Game.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game
{
    public abstract class BaseGame : Microsoft.Xna.Framework.Game
    {
        protected static GamePadStateManager PlayerOne
        {
            get { return GamePadStateManager.PlayerOne; }
        }

        protected BaseGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected virtual Color GraphicsClearColor
        {
            get { return Color.CornflowerBlue; }
        }

        protected GraphicsDeviceManager Graphics { get; set; }
        protected SpriteBatch SpriteBatch { get; set; }

        protected MouseStateManager MouseState
        {
            get { return MouseStateManager.MouseState; }
        }

        protected KeyboardStateManager KeyboardState
        {
            get { return KeyboardStateManager.KeyboardState; }
        }

        protected abstract void GameUpdateLogic(GameTime gameTime);

        protected override void Initialize()
        {
#if DEBUG
            IsMouseVisible = true;
#endif

            base.Initialize();
        }

        protected override void LoadContent()
        {
            CreateNewSpriteBachToDrawTextures();
        }

        protected override void Update(GameTime gameTime)
        {
            CaptureState();

            if (PlayerOne.IsBackButtonPressed) Exit();

            GameUpdateLogic(gameTime);

            base.Update(gameTime);
        }

        protected void CreateNewSpriteBachToDrawTextures()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected Model GetModel(string modelName)
        {
            return Content.Load<Model>(modelName);
        }

        private void CaptureState()
        {
            PlayerOne.Capture();
            MouseState.Capture();
            KeyboardState.Capture();
        }
    }
}