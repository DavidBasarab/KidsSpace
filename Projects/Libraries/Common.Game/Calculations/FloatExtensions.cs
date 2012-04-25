using System;
using Microsoft.Xna.Framework;

namespace Common.Game.Calculations
{
    public static class FloatExtensions
    {
        private static double Precision
        {
            get { return .0000001; }
        }

        public static float Clamp(this float number, float min, float max)
        {
            return MathHelper.Clamp(number, min, max);
        }

        public static float Clamp(this float number, float? min, float? max)
        {
            if (min.HasValue && max.HasValue) return MathHelper.Clamp(number, min.Value, max.Value);

            return number;
        }

        public static bool IsEqualTo(this float value, float number)
        {
            return Math.Abs(value - number) < Precision;
        }
    }
}