using System.Collections.Generic;
using System.Linq;
using Common.Game;
using Common.Game.Graphics.Cameras;
using Common.Game.Graphics.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sample1
{
    public class Sample1Game : BaseGame
    {
        private IList<GenericModel> _models;
        private Model Ship { get; set; }
        private Matrix[] Transforms { get; set; }

        public IList<GenericModel> Models
        {
            get { return _models ?? (_models = new List<GenericModel>()); }
        }

        public FreeCamera Camera { get; set; }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var numberOfModelsDrawn = 0;

            //var view = Matrix.CreateLookAt(new Vector3(0, 300, 2000), Vector3.Zero, Vector3.Up);
            //var projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), GraphicsDevice.Viewport.AspectRatio, 0.1f, 10000.0f);

            foreach(var model in Models.Where(model => Camera.IsInView(model.BoundingSphere)))
            {
                numberOfModelsDrawn++;
                model.Draw(Camera.View, Camera.Projection);
            }

            if (numberOfModelsDrawn == 0) GraphicsDevice.Clear(Color.Red);

            base.Draw(gameTime);
        }

        protected override void GameUpdateLogic(GameTime gameTime)
        {
            UpdateCamera(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            //LoadShip();
            //for (var y = 0; y < 3; y++)
            //{
            //    for (var x = 0; x < 3; x++)
            //    {
            //        var position = new Vector3(-600 + x * 600, -400 + y * 400, 0);

            //        var model = new GenericModel(GetModel("ship"), position, new Vector3(0, MathHelper.ToRadians(90) * (y * 3 + x), 0), new Vector3(0.25f), GraphicsDevice);

            //        Models.Add(model);
            //    }
            //}
            var model = new GenericModel(GetModel("ship"), Vector3.Zero, Vector3.Zero, new Vector3(0.6f), GraphicsDevice);

            Models.Add(model);

            Camera = new FreeCamera(GraphicsDevice, new Vector3(1000, 0, -2000), MathHelper.ToRadians(153), MathHelper.ToRadians(5));
        }

        protected override bool ShouldGameExit()
        {
            return base.ShouldGameExit() || KeyboardState.IsKeyDown(Keys.Escape);
        }

        protected override void UnloadContent() {}

        private void LoadShip()
        {
            Ship = GetModel("ship");

            Transforms = new Matrix[Ship.Bones.Count];

            Ship.CopyAbsoluteBoneTransformsTo(Transforms);
        }

        private void UpdateCamera(GameTime gameTime)
        {
            Camera.Rotate(MouseState.DeltaX * .01f, MouseState.DeltaY * .01f);

            var translation = Vector3.Zero;

            // Determine in which direction to move the camera
            if (KeyboardState.IsWDown) translation += Vector3.Forward;
            if (KeyboardState.IsSDown) translation += Vector3.Backward;
            if (KeyboardState.IsADown) translation += Vector3.Left;
            if (KeyboardState.IsDDown) translation += Vector3.Right;

            // Move 3 units per millisecond, independent of frame rate
            translation *= 3 * gameTime.GetTotalMilliseconds();

            // Move the camera
            Camera.Move(translation);

            // Update the camera
            Camera.Update();
        }
    }
}