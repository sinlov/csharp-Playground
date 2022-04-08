using System.Security.Cryptography;

namespace FastCodeZoo.Algorithm
{
    public class Md5Encipher
    {
        public static string GetMD5Hash(string input)
        {
            return HashAlgorithmHelper.ComputeHash<MD5>(input);
        }
    }
}