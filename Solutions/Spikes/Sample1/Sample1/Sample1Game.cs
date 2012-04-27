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

        public ChaseCamera Camera { get; set; }

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
            UpdateModel(gameTime);
            UpdateCamera(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            CreateModel(GetModel("ship"), new Vector3(0, 400, 0), Vector3.Zero, new Vector3(0.4f));
            CreateModel(GetModel("ground"), Vector3.Zero, Vector3.Zero, Vector3.One);

            Camera = new ChaseCamera(new Vector3(0, 400, 1500), new Vector3(0, 200, 0), new Vector3(0, 0, 0), GraphicsDevice);
        }

        protected override bool ShouldGameExit()
        {
            return base.ShouldGameExit() || KeyboardState.IsKeyDown(Keys.Escape);
        }

        protected override void UnloadContent() {}

        private void CreateModel(Model model, Vector3 position, Vector3 rotation, Vector3 scale)
        {
            var genericModel = new GenericModel(model, position, rotation, scale, GraphicsDevice);

            Models.Add(genericModel);
        }

        private void UpdateCamera(GameTime gameTime) {}

        private void UpdateModel(GameTime gameTime)
        {
            var rotationChange = new Vector3(0, 0, 0);

            // Determin which axes the ship should be rotated on, if any
            if (KeyboardState.IsWDown) rotationChange += new Vector3(1, 0, 0);
            if (KeyboardState.IsSDown) rotationChange += new Vector3(-1, 0, 0);
            if (KeyboardState.IsADown) rotationChange += new Vector3(0, 1, 0);
            if (KeyboardState.IsDDown) rotationChange += new Vector3(0, -1, 0);

            Models[0].Rotation += rotationChange * 0.025f;

            if (KeyboardState.IsSpaceDown)
            {
                return;
            }

            // Determine what direction to move in
            Matrix rotation = Matrix.CreateFromYawPitchRoll(Models[0].Rotation.Y, Models)
        }
    }
}