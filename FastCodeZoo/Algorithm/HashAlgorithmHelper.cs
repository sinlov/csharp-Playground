using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FastCodeZoo.Algorithm
{
    public static class HashAlgorithmHelper
    {
        /// <summary>
        /// 使用方法
        /// <example>
        /// <code>
        ///     HashAlgorithmHelper.ComputeHash<MD5>();
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="input">string need Encoding.UTF8</param>
        /// <typeparam name="THashAlgorithm"></typeparam>
        /// <returns></returns>
        public static string ComputeHash<THashAlgorithm>(string input) where THashAlgorithm : HashAlgorithm
        {
            var data = HashAlgorithmInstances<THashAlgorithm>.Instance.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            foreach (var item in data)
            {
                sBuilder.Append(item.ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static byte[]
            ComputeHashByteUTF8<THashAlgorithm>
            (
                string str
            )
            where THashAlgorithm : HashAlgorithm
        {
            return HashAlgorithmInstances<THashAlgorithm>.Instance.ComputeHash(Encoding.UTF8.GetBytes(str));
        }

        public static byte[]
            ComputeHashByte<THashAlgorithm>
            (
                byte[] bytes
            )
            where THashAlgorithm : HashAlgorithm
        {
            return HashAlgorithmInstances<THashAlgorithm>.Instance.ComputeHash(bytes);
        }

        public static string
            ComputeHash<THashAlgorithm>
            (
                byte[] bytes
            )
            where THashAlgorithm : HashAlgorithm
        {
            var data = ComputeHashByte<THashAlgorithm>(bytes);

            var sBuilder = new StringBuilder();

            foreach (var item in data)
            {
                sBuilder.Append(item.ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static byte[]
            ComputeHashByte<THashAlgorithm>
            (
                byte[] buffer, int offset, int count
            )
            where THashAlgorithm : HashAlgorithm
        {
            return HashAlgorithmInstances<THashAlgorithm>.Instance.ComputeHash(buffer, offset, count);
        }

        public static string
            ComputeHash<THashAlgorithm>
            (
                byte[] buffer, int offset, int count
            )
            where THashAlgorithm : HashAlgorithm
        {
            var data = ComputeHashByte<THashAlgorithm>(buffer, offset, count);

            var sBuilder = new StringBuilder();

            foreach (var item in data)
            {
                sBuilder.Append(item.ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static byte[]
            ComputeHashByte<THashAlgorithm>
            (
                Stream inputStream
            )
            where THashAlgorithm : HashAlgorithm
        {
            return HashAlgorithmInstances<THashAlgorithm>.Instance.ComputeHash(inputStream);
        }

        public static string
            ComputeHash<THashAlgorithm>
            (
                Stream inputStream
            )
            where THashAlgorithm : HashAlgorithm
        {
            var data = ComputeHashByte<THashAlgorithm>(inputStream);

            var sBuilder = new StringBuilder();

            foreach (var item in data)
            {
                sBuilder.Append(item.ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static byte[]
            ComputeHashByte<THashAlgorithm>
            (
                FileStream fileStream
            )
            where THashAlgorithm : HashAlgorithm
        {
            return HashAlgorithmInstances<THashAlgorithm>.Instance.ComputeHash(fileStream);
        }

        public static string
            ComputeHash<THashAlgorithm>
            (
                FileStream fileStream
            )
            where THashAlgorithm : HashAlgorithm
        {
            var data = ComputeHashByte<THashAlgorithm>(fileStream);

            var sBuilder = new StringBuilder();

            foreach (var item in data)
            {
                sBuilder.Append(item.ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}