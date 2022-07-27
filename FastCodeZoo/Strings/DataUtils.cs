namespace FastCodeZoo.Strings
{
    public static class DataUtils
    {
        public static string encode(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return "";
            }

            if (data.Length < 52)
            {
                return data;
            }

            char[] fromD = data.ToCharArray();

            replaceChatAtIndex(ref fromD, 1, 38);
            replaceChatAtIndex(ref fromD, 8, 43);
            replaceChatAtIndex(ref fromD, 17, 46);
            replaceChatAtIndex(ref fromD, 21, 52);

            return new string(fromD);
        }

        private static void replaceChatAtIndex(ref char[] fromD, int left, int right)
        {
            char l = fromD[left];
            char r = fromD[right];
            fromD[left] = r;
            fromD[right] = l;
        }
    }
}