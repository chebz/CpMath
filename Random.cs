namespace cpGames.Math
{
    public class Random
    {
        public static System.Random r = new System.Random();

        public static float Value { get { return (float) r.NextDouble(); } }

        public static float Range(float min, float max)
        {
            return min + (max - min)*Value;
        }

        public static bool RandomChance(float chance)
        {
            return Value <= chance;
        }
    }
}