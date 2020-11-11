using System;
using System.Collections.Generic;

namespace MatrixVectorMathHelper.Maths
{
    /// <summary>
    /// A class containing many extension methods and extension helpers
    /// </summary>
    public static class MathAddons
    {
        /// <summary>
        /// Clamps a given value between 2 other values. 
        /// so Clamp(25, 0, 100) will always be between 0 and 100, never below or above
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Clamp(this float value, float min, float max)
        {
            // return value < min ? min : (value > max ? max : value);

            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static int Clamp(this int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static Vector3 Clamp(this Vector3 vec, float min, float max)
        {
            return new Vector3(
                Clamp(vec.X, min, max),
                Clamp(vec.Y, min, max),
                Clamp(vec.Z, min, max));
        }

        /// <summary>
        /// Looks at both value1 and value2 and returns the smallest one. so Min(4, 6) returns 4
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static float Min(this float value1, float value2)
        {
            return value1 < value2 ? value1 : value2;
        }

        /// <summary>
        /// Looks at both value1 and value2 and returns the biggest one. so Max(4, 6) returns 6
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static float Max(this float value1, float value2)
        {
            return value1 > value2 ? value1 : value2;
        }

        public static float Sinf(this float a)
        {
            return (float)Math.Sin(a);
        }

        public static float Cosf(this float a)
        {
            return (float)Math.Cos(a);
        }

        public static float ACosf(this float a)
        {
            return (float)Math.Acos(a);
        }

        public static float Tanf(this float a)
        {
            return (float)Math.Tan(a);
        }

        public static float Sqrtf(this float a)
        {
            return (float)Math.Sqrt(a);
        }

        public static Vector3 MultiplyPoint(this Matrix4 a, Vector3 b)
        {
            Vector3 p = new Vector3(
                a.M[0] * b.X + a.M[1] * b.Y + a.M[2] * b.Z + a.M[3],
                a.M[4] * b.X + a.M[5] * b.Y + a.M[6] * b.Z + a.M[7],
                a.M[8] * b.X + a.M[9] * b.Y + a.M[10] * b.Z + a.M[11]);
            float w = a.M[12] * b.X + a.M[13] * b.Y + a.M[14] * b.Z + a.M[15];
            return p / w;
        }

        public static Vector3 MultiplyDirection(this Matrix4 a, Vector3 b)
        {
            return new Vector3(
                a.M[0] * b.X + a.M[1] * b.Y + a.M[2] * b.Z,
                a.M[4] * b.X + a.M[5] * b.Y + a.M[6] * b.Z,
                a.M[8] * b.X + a.M[9] * b.Y + a.M[10] * b.Z);
        }

        public static Vector3 FromList(this List<float> list, int startPoint)
        {
            try
            {
                // check if list.count is bigger than startPOint or something...
                //cant be botheredtho
                return new Vector3(
                    list[startPoint],
                    list[startPoint + 1],
                    list[startPoint + 2]);
            }
            catch
            {
                return new Vector3(0, 0, 0);
            }
        }

        public static Vector3 DegreesToEuler(float x, float y, float z)
        {
            return new Vector3(x / 60, y / 60, z / 60);
        }

        public static Vector3 DegreesToEuler(this Vector3 degrees)
        {
            return new Vector3(degrees.X / 60, degrees.Y / 60, degrees.Z / 60);
        }

        public static int ForceParse(this string integer)
        {
            return int.TryParse(integer, out int value) ? value : 0;
        }

        public static float ForceParsef(this string val)
        {
            return float.TryParse(val, out float value) ? value : 0.0f;
        }

        public static float[] ToFloats(this string[] array)
        {
            float[] floats = new float[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                floats[i] = array[i].ForceParsef();
            }
            return floats;
        }

        public static int[] ToInts(this string[] array)
        {
            int[] ints = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                ints[i] = array[i].ForceParse();
            }
            return ints;
        }

        public static int ToInt(this float value)
        {
            return ForceParse(value.ToString());
        }

        /// <summary>
        /// Creates a vector from an array of floats
        /// </summary>
        /// <param name="floats"></param>
        /// <param name="setVecAllWith1Element">If the array's length is 1, then if this is true, the vector's X, Y and Z values 
        /// are set to that one element (in the array). otherwise only the X component is set</param>
        /// <returns></returns>
        public static Vector3 ToVector(this float[] floats, bool setVecAllWith1Element = true)
        {
            if (floats == null)
                return Vector3.Zero;
            if (floats.Length >= 3)
            {
                return new Vector3(floats[0], floats[1], floats[2]);
            }
            else if (floats.Length == 2)
            {
                return new Vector3(floats[0], floats[1], 0);
            }
            else if (floats.Length == 1)
            {
                return setVecAllWith1Element ? new Vector3(floats[0]) : new Vector3(floats[0], 0, 0);
            }
            else return Vector3.Zero;
        }

        public static bool IsNegative(this float value)
        {
            return value < 0;
        }

        public static bool IsNegative(this int value)
        {
            return value < 0;
        }
    }
}
