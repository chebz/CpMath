using System;

namespace cpGames.Math
{
    public class Math
    {
        public static float PI = (float) System.Math.PI;

        public static float PI2 = (float) System.Math.PI*2;

        public static Random Random = new Random();

        public static float Pow2(float n)
        {
            return n*n;
        }

        public static float Sqrt(float n)
        {
            return (float) System.Math.Sqrt(n);
        }

        public static float Sin(float a)
        {
            return (float) System.Math.Sin(a/180*PI);
        }

        public static float Cos(float a)
        {
            return (float) System.Math.Cos(a/180*PI);
        }

        public static float Asin(float n)
        {
            return (float)System.Math.Asin(Clamp(n, -1, 1)) / PI * 180;
        }

        public static float Acos(float n)
        {
            return (float)System.Math.Acos(Clamp(n, -1, 1)) / PI * 180;
        }

        public static float Abs(float n)
        {
            return n > 0 ? n : n*-1;
        }

        public static float Clamp(float n, float min, float max)
        {
            return Min(Max(n, min), max);
        }

        public static float Min(float n1, float n2)
        {
            return n1 < n2 ? n1 : n2;
        }

        public static float Max(float n1, float n2)
        {
            return n1 > n2 ? n1 : n2;
        }

        public static float AngleToPoint(CpVector2 point,
            CpVector2 fwd,
            CpVector2 position)
        {
            var dir = CpVector2.Subtract(point, position).Normalize();
            var angle = CpVector2.Angle(fwd, dir);

            if (!AnglePositive(dir, fwd))
                angle *= -1;

            if (float.IsNaN(angle))
                throw new Exception("angle is NaN!");
            return angle;
        }

        public static bool AnglePositive(CpVector2 dir, CpVector2 fwd)
        {
            CpVector2.TEMP2.x = fwd.y;
            CpVector2.TEMP2.y = -fwd.x;
            return CpVector2.Dot(CpVector2.TEMP2, dir) > 0;
        }
    }
}