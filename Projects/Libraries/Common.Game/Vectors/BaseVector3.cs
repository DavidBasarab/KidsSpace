using Microsoft.Xna.Framework;

namespace Common.Game.Vectors
{
    public class BaseVector3
    {
        public static BaseVector3 Backward
        {
            get { return Vector3.Backward; }
        }

        public static BaseVector3 Down
        {
            get { return Vector3.Down; }
        }

        public static BaseVector3 Forward
        {
            get { return Vector3.Forward; }
        }

        public static BaseVector3 Left
        {
            get { return Vector3.Left; }
        }

        public static BaseVector3 One
        {
            get { return Vector3.One; }
        }

        public static BaseVector3 Right
        {
            get { return Vector3.Right; }
        }

        public static BaseVector3 UnitX
        {
            get { return Vector3.UnitX; }
        }

        public static BaseVector3 UnitY
        {
            get { return Vector3.UnitY; }
        }

        public static BaseVector3 UnitZ
        {
            get { return Vector3.UnitZ; }
        }

        public static BaseVector3 Up
        {
            get { return Vector3.Up; }
        }

        public static BaseVector3 Zero
        {
            get { return Vector3.Zero; }
        }

        public static BaseVector3 Transform(BaseVector3 vector, Matrix matrix)
        {
            return Vector3.Transform(vector.Vector, matrix);
        }

        public static BaseVector3 operator +(BaseVector3 value1, BaseVector3 value2)
        {
            return value1.Vector + value2.Vector;
        }

        //public static BaseVector3 operator +(BaseVector3 value1, Vector3 value2)
        //{
        //    return new BaseVector3(value1.Vector + value2);
        //}

        //public static BaseVector3 operator +(Vector3 value1, BaseVector3 value2)
        //{
        //    return new BaseVector3(value1 + value2.Vector);
        //}

        public static BaseVector3 operator /(BaseVector3 value1, BaseVector3 value2)
        {
            return value1.Vector / value2.Vector;
        }

        public static BaseVector3 operator /(BaseVector3 value, float divider)
        {
            return value.Vector / divider;
        }

        public static BaseVector3 operator /(BaseVector3 value1, Vector3 value2)
        {
            return new BaseVector3(value1.Vector / value2);
        }

        public static BaseVector3 operator /(Vector3 value1, BaseVector3 value2)
        {
            return new BaseVector3(value1 / value2.Vector);
        }

        public static bool operator ==(BaseVector3 value1, BaseVector3 value2)
        {
            return value2 != null && (value1 != null && value1.Vector == value2.Vector);
        }

        public static implicit operator Vector3(BaseVector3 value)
        {
            return value.Vector;
        }

        public static implicit operator BaseVector3(Vector3 value)
        {
            return new BaseVector3(value);
        }

        public static bool operator !=(BaseVector3 value1, BaseVector3 value2)
        {
            return !(value1 == value2);
        }

        public static BaseVector3 operator *(BaseVector3 value1, BaseVector3 value2)
        {
            return value1.Vector * value2.Vector;
        }

        public static BaseVector3 operator *(BaseVector3 value, float scaleFactor)
        {
            return value.Vector * scaleFactor;
        }

        public static BaseVector3 operator *(BaseVector3 value1, Vector3 value2)
        {
            return new BaseVector3(value1.Vector * value2);
        }

        public static BaseVector3 operator *(Vector3 value1, BaseVector3 value2)
        {
            return new BaseVector3(value1 * value2.Vector);
        }

        public static BaseVector3 operator -(BaseVector3 value1, BaseVector3 value2)
        {
            return value1.Vector - value2.Vector;
        }

        public static BaseVector3 operator -(BaseVector3 value1, Vector3 value2)
        {
            return new BaseVector3(value1.Vector - value2);
        }

        public static BaseVector3 operator -(Vector3 value1, BaseVector3 value2)
        {
            return new BaseVector3(value1 - value2.Vector);
        }

        public static BaseVector3 operator -(BaseVector3 value)
        {
            return -value.Vector;
        }

        public BaseVector3(Vector3 vector)
        {
            Vector = vector;
        }

        public BaseVector3(float x, float y, float z)
        {
            Vector = new Vector3(x, y, z);
        }

        public BaseVector3(float value)
        {
            Vector = new Vector3(value);
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        private Vector3 Vector { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == typeof(BaseVector3) && Equals((BaseVector3)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Vector.GetHashCode();
            }
        }

        public bool Equals(BaseVector3 other)
        {
            if (ReferenceEquals(null, other)) return false;

            return ReferenceEquals(this, other) || other.Vector.Equals(Vector);
        }
    }
}