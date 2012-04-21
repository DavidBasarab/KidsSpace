using System;
using Common.Game.Calculations;
using Common.Game.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGameByExample
{
    /// <summary>
    ///     This is the main type for your game
    /// </summary>
    public class FirstGame : Game
    {
        private const float TimePerSquare = 0.75f;

        private static bool WasBackPressed
        {
            get { return GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed; }
        }

        private readonly Color[] _colors = new[] { Color.Red, Color.Green, Color.Blue };
        private readonly Random _random = new Random();

        private Rectangle _currentSquare;

        public FirstGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        private int PlayerScore { get; set; }

        private GraphicsDeviceManager Graphics { get; set; }

        private SpriteBatch SpriteBatch { get; set; }
        private Texture2D SquareTexture { get; set; }

        private CurrentMouseState MouseState
        {
            get { return CurrentMouseState.MouseState; }
        }

        private int Height
        {
            get { return Window.ClientBounds.Height; }
        }

        private int Width
        {
            get { return Window.ClientBounds.Width; }
        }

        private float TimeRemaining { get; set; }

        private Color[] Colors
        {
            get { return _colors; }
        }

        public float ImageScale { get; set; }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            SpriteBatch.Begin();

            SpriteBatch.Draw(SquareTexture, _currentSquare, Colors[PlayerScore % 3]);

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            base.Initialize();

            IsMouseVisible = true;

            ImageScale = 1.0f;
        }

        protected override void LoadContent()
        {
            CreateNewSpriteBachToDrawTextures();

            SquareTexture = Content.Load<Texture2D>("SQUARE");
        }

        protected override void UnloadContent()
        {
            SquareTexture.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            if (WasBackPressed) Exit();

            base.Update(gameTime);

            if (TimeRemaining.IsEqualTo(0.0f))
            {
                _currentSquare = new Rectangle(GetXPostion(), GetYPostion(), GetWidth(), GetHeight());

                TimeRemaining = TimePerSquare;
            }

            if (MouseState.IsLeftButtonPressed && MouseState.MouseInRectangle(_currentSquare))
            {
                ImageScale = ImageScale - 0.05f;

                PlayerScore++;
                TimeRemaining = 0;
            }

            ImageScale = ImageScale.Clamp(0.4f, 1.00f);

            TimeRemaining = MathHelper.Max(0, TimeRemaining - (float)gameTime.ElapsedGameTime.TotalSeconds);

            Window.Title = string.Format("Score: {0} | ImageScale: {1}", PlayerScore, ImageScale);
        }

        private void CreateNewSpriteBachToDrawTextures()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        private int GetHeight()
        {
            return (int)(25 * ImageScale);
        }

        private int GetWidth()
        {
            return (int)(25 * ImageScale);
        }

        private int GetXPostion()
        {
            return _random.Next(0, Width - 25);
        }

        private int GetYPostion()
        {
            return _random.Next(Height - 25);
        }
    }
}