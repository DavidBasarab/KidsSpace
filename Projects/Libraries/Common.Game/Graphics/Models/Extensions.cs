using System;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game.Graphics.Models
{
    internal static class Extensions
    {
        public static int GetBoneCount(this Model model)
        {
            return model == null ? 0 : model.Bones.Count;
        }
    }
}