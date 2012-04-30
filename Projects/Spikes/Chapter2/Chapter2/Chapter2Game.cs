using System.Collections.Generic;
using Common.Game;
using Common.Game.Graphics.Cameras;
using Common.Game.Graphics.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Chapter2
{
    public class Chapter2Game : BaseGame
    {
        private IList<GenericModel> _models;

        public IList<GenericModel> Models
        {
            get { return _models ?? (_models = new List<GenericModel>()); }
        }

        public FreeCamera Camera { get; set; }

        protected override void AdditionalConstructorWork()
        {
            // 1600 x 900 I would love to do sometime
            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 800;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach(var model in Models)
            {
                if (Camera.IsInView(model.BoundingSphere))
                {
                    model.Draw(Camera.View, Camera.Projection);
                }
            }

            base.Draw(gameTime);
        }

        protected override void GameUpdateLogic(GameTime gameTime)
        {
            UpdateCamera(gameTime);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            CreateShip();
            CreateGround();
            CreateCamera();
        }

        protected override void UnloadContent() {}

        private void CreateCamera()
        {
            Camera = new FreeCamera(GraphicsDevice, new Vector3(1000, 500, -2000), MathHelper.ToRadians(153), MathHelper.ToRadians(5));
        }

        private void CreateGround()
        {
            var model = new GenericModel(GetModel("ground"), Vector3.Zero, Vector3.Zero, Vector3.One, GraphicsDevice);

            Models.Add(model);
        }

        private void CreateShip()
        {
            var model = new GenericModel(GetModel("ship"), new Vector3(0, 400, 0), Vector3.Zero, new Vector3(1f), GraphicsDevice);

            Models.Add(model);
        }

        protected override bool ShouldGameExit()
        {
            return base.ShouldGameExit() || KeyboardState.IsKeyDown(Keys.Escape);
        }

        private void UpdateCamera(GameTime gameTime)
        {
            Camera.Rotate(MouseState.DeltaX * .005f, MouseState.DeltaY * .005f);

            var translation = Vector3.Zero;

            if (KeyboardState.IsWDown) translation += Vector3.Forward;
            if (KeyboardState.IsSDown) translation += Vector3.Backward;
            if (KeyboardState.IsADown) translation += Vector3.Left;
            if (KeyboardState.IsDDown) translation += Vector3.Right;

            // Move 3 units per millisecond, independent of frame rate
            translation *= 4 * gameTime.GetTotalMilliseconds();

            Camera.Move(translation);

            Camera.Update();
        }
    }
}