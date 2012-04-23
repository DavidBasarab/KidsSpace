using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Common.Game
{
    public static class Extensions
    {
        public static float GetTotalMilliseconds(this GameTime gameTime)
        {
            return (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }
}
