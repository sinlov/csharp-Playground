namespace FastCodeZoo.Strings
{
    public static class StringSplit
    {
        public static string[] SplitByCount(string target, char separator, int count)
        {
            return target.Split(new char[] { separator }, count);
        }
    }
}