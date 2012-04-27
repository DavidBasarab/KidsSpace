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
            var newValue = value1.Value + value2.Value;

            return Clamp(newValue, value1.Min ?? value2.Min, value1.Max ?? value1.Max);
        }

        public static bool operator ==(float value1, ClampFloat value2)
        {
            return Math.Abs(value1 - value2.Value) < Tollerance;
        }

        public static bool operator ==(ClampFloat value1, float value2)
        {
            return Math.Abs(value1.Value - value2) < Tollerance;
        }

        public static implicit operator float(ClampFloat value)
        {
            return value.Value;
        }

        public static implicit operator ClampFloat(float value)
        {
            return new ClampFloat(value);
        }

        public static bool operator !=(float value1, ClampFloat value2)
        {
            return !(Math.Abs(value1 - value2.Value) < Tollerance);
        }

        public static bool operator !=(ClampFloat value1, float value2)
        {
            return !(Math.Abs(value1.Value - value2) < Tollerance);
        }

        public static ClampFloat operator -(ClampFloat value1, ClampFloat value2)
        {
            var newValue = value1.Value - value2.Value;

            return Clamp(newValue, value1.Min, value1.Max);
        }

        private static ClampFloat Clamp(float newValue, float? min, float? max)
        {
            if (min.HasValue && max.HasValue) newValue = MathHelper.Clamp(newValue, min.Value, max.Value);

            return new ClampFloat(newValue, min, max);
        }

        private float _value;

        public ClampFloat(float number)
        {
            _value = number;
        }

        public ClampFloat() {}

        public ClampFloat(float number, float? min, float? max)
        {
            Max = max;
            Min = min;

            _value = number.Clamp(min, max);
        }

        public float? Min { get; set; }

        public float? Max { get; set; }

        public float Value
        {
            get { return _value; }
            set { _value = Clamp(value, Min, Max); }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(ClampFloat) && Equals((ClampFloat)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(ClampFloat other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || other.Value.Equals(Value);
        }
    }
}