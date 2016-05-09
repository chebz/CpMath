using cpGames.Serialization;

namespace cpGames.Math
{
    [Common.Class("CpVector2")]
    public class CpVector2
    {
        public static readonly CpVector2 TEMP1 = new CpVector2();

        public static readonly CpVector2 TEMP2 = new CpVector2();

        public static readonly CpVector2 UP = new CpVector2(0, 1);

        public static readonly CpVector2 RIGHT = new CpVector2(1, 0);

        public static readonly CpVector2 DOWN = new CpVector2(0, -1);

        public static readonly CpVector2 LEFT = new CpVector2(-1, 0);

        public float x;

        public float y;

        public CpVector2() {}

        public CpVector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public CpVector2(CpVector2 other)
        {
            x = other.x;
            y = other.y;
        }

        public CpVector2 CopyFrom(CpVector2 other)
        {
            x = other.x;
            y = other.y;
            return this;
        }

        public float Length()
        {
            return Math.Sqrt(x*x + y*y);
        }

        public CpVector2 Normalize()
        {
            var length = Length();
            x = x/length;
            y = y/length;
            return this;
        }

        public CpVector2 Rotate(float a)
        {
            a *= -1; //clockwise is positive
            var x1 = x*Math.Cos(a) - y*Math.Sin(a);
            var y1 = y*Math.Cos(a) + x*Math.Sin(a);
            x = x1;
            y = y1;
            return this;
        }

        public static float Angle(CpVector2 v1, CpVector2 v2)
        {
            var dot = Dot(v1, v2);
            var l1 = v1.Length();
            var l2 = v2.Length();
            return Math.Acos(dot/l1/l2);
        }

        public static float Dot(CpVector2 v1, CpVector2 v2)
        {
            return v1.x*v2.x + v1.y*v2.y;
        }

        public static CpVector2 operator +(CpVector2 v1, CpVector2 v2)
        {
            TEMP1.x = v1.x + v2.x;
            TEMP1.y = v1.y + v2.y;
            return TEMP1;
        }

        public CpVector2 Add(CpVector2 other)
        {
            x += other.x;
            y += other.y;
            return this;
        }

        public static CpVector2 operator -(CpVector2 v1, CpVector2 v2)
        {
            TEMP1.x = v1.x - v2.x;
            TEMP1.y = v1.y - v2.y;
            return TEMP1;
        }

        public CpVector2 Subtract(CpVector2 other)
        {
            x -= other.x;
            y -= other.y;
            return this;
        }

        public static CpVector2 Subtract(CpVector2 v1, CpVector2 v2)
        {
            TEMP1.x = v1.x - v2.x;
            TEMP1.y = v1.y - v2.y;
            return TEMP1;
        }

        public static CpVector2 operator *(CpVector2 v, float n)
        {
            TEMP1.x = v.x*n;
            TEMP1.y = v.y*n;
            return TEMP1;
        }

        public CpVector2 Mult(float n)
        {
            x *= n;
            y *= n;
            return this;
        }

        public CpVector2 Lerp(CpVector2 v, float n)
        {
            TEMP1.CopyFrom(this);
            n = Math.Clamp(n, 0, 1);
            TEMP1.x += (v.x - x) * n;
            TEMP1.y += (v.y - y) * n;
            return TEMP1;
        }
        
        public static float Distance(CpVector2 v1, CpVector2 v2)
        {
            return TEMP1.CopyFrom(v1).Subtract(v2).Length();
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", x, y);
        }
    }
}