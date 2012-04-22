using Common.Game.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game
{
    public abstract class BaseGame : Microsoft.Xna.Framework.Game
    {
        protected static CurrentGamePadState PlayerOne
        {
            get { return CurrentGamePadState.PlayerOne; }
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

        protected CurrentMouseState MouseState
        {
            get { return CurrentMouseState.MouseState; }
        }

        protected override void LoadContent()
        {
            CreateNewSpriteBachToDrawTextures();
        }

        protected override void Initialize()
        {
#if DEBUG
            IsMouseVisible = true;
#endif

            base.Initialize();
        }

        protected void CreateNewSpriteBachToDrawTextures()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected Model GetModel(string modelName)
        {
            return Content.Load<Model>(modelName);
        }
    }
}