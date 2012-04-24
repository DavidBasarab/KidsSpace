using System;
using Common.Game.Calculations;
using Microsoft.Xna.Framework;

namespace Common.Game.Numbers
{
    public class ClampFloat
    {
        private const float Tollerance = 0.00000000001f;

        public static ClampFloat operator +(ClampFloat value1, ClampFloat value2)
        {
            var newValue = value1.Number + value2.Number;

            return Clamp(value1, newValue);
        }

        public static bool operator ==(float value1, ClampFloat value2)
        {
            return Math.Abs(value1 - value2.Number) < Tollerance;
        }

        public static bool operator ==(ClampFloat value1, float value2)
        {
            return Math.Abs(value1.Number - value2) < Tollerance;
        }

        public static implicit operator float(ClampFloat value)
        {
            return value.Number;
        }

        public static implicit operator ClampFloat(float value)
        {
            return new ClampFloat(value);
        }

        public static bool operator !=(float value1, ClampFloat value2)
        {
            return !(Math.Abs(value1 - value2.Number) < Tollerance);
        }

        public static bool operator !=(ClampFloat value1, float value2)
        {
            return !(Math.Abs(value1.Number - value2) < Tollerance);
        }

        public static ClampFloat operator -(ClampFloat value1, ClampFloat value2)
        {
            var newValue = value1.Number - value2.Number;

            return Clamp(value1, newValue);
        }

        private static ClampFloat Clamp(ClampFloat value1, float newValue)
        {
            if (value1.Min.HasValue && value1.Max.HasValue) return MathHelper.Clamp(newValue, value1.Min.Value, value1.Max.Value);

            return newValue;
        }

        public ClampFloat(float number)
        {
            Number = number;
        }

        public ClampFloat() {}

        public ClampFloat(float number, float min, float max)
        {
            Number = number;
            Max = max;
            Min = min;

            Number = Number.Clamp(min, max);
        }

        public float? Min { get; set; }

        public float? Max { get; set; }

        private float Number { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(ClampFloat) && Equals((ClampFloat)obj);
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public bool Equals(ClampFloat other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || other.Number.Equals(Number);
        }
    }
}