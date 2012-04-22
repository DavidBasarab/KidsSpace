using System.Collections.Generic;
using Common.Game;
using Common.Game.Graphics.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var view = Matrix.CreateLookAt(new Vector3(0, 300, 2000), Vector3.Zero, Vector3.Up);

            var projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), GraphicsDevice.Viewport.AspectRatio, 0.1f, 10000.0f);

            foreach(var model in Models)
            {
                model.Draw(view, projection);
            }

            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            //LoadShip();
            for (var y = 0; y < 3; y++)
            {
                for (var x = 0; x < 3; x++)
                {
                    var position = new Vector3(-600 + x * 600, -400 + y * 400, 0);

                    var model = new GenericModel(GetModel("ship"), position, new Vector3(0, MathHelper.ToRadians(90) * (y * 3 + x), 0), new Vector3(0.25f), GraphicsDevice);

                    Models.Add(model);
                }
            }
        }

        protected override void UnloadContent() {}

        protected override void Update(GameTime gameTime)
        {
            if (PlayerOne.IsBackButtonPressed) Exit();

            base.Update(gameTime);
        }

        private void LoadShip()
        {
            Ship = GetModel("ship");

            Transforms = new Matrix[Ship.Bones.Count];

            Ship.CopyAbsoluteBoneTransformsTo(Transforms);
        }
    }
}