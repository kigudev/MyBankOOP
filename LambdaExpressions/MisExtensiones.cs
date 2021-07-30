namespace LambdaExpressions
{
    public static class MisExtensiones
    {
        public static int MiCount(this int[] param)
        {
            return 3;
        }

        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', ',', '?' }).Length;
        }
    }
}