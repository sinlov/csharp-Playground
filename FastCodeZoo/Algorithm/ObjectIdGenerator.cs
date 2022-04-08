using System;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;

namespace FastCodeZoo.Algorithm
{
    internal static class ObjectIdGenerator
    {
        private static readonly DateTime Epoch =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private static readonly object _innerLock = new object();
        private static int _counter;
        private static readonly byte[] _machineHash = GenerateHostHash();

        private static readonly byte[] _processId =
            GetIntBytes(ProcessId(), 2);

        public static byte[] Generate()
        {
            var oid = new byte[12];
            var cIDx = 0;

            Array.Copy(TimeNowBytes(), 0, oid, cIDx, 4);
            cIDx += 4;

            Array.Copy(_machineHash, 0, oid, cIDx, 3);
            cIDx += 3;

            Array.Copy(_processId, 0, oid, cIDx, 2);
            cIDx += 2;

            Array.Copy(GetIntBytes(Counter(), 3), 0, oid, cIDx, 3);

            return oid;
        }

        private static byte[] TimeNowBytes()
        {
            var now = DateTime.UtcNow;
            var diff = now - Epoch; //取与1970的时间差
            int timeVal = Convert.ToInt32(Math.Floor(diff.TotalSeconds)); //取时间差的总秒数
            //return BitConverter.GetBytes(timeVal);//低位数在前面的字节，字符串格式化时，排序变得无序
            return GetIntBytes(timeVal, 4);
        }

        private static byte[] GetIntBytes(int val, int len)
        {
            byte[] b = new byte[len];
            for (int i = 0; i < len; i++)
            {
                int shift = 8 * (len - 1 - i);
                b[i] = (byte)(val >> shift);
            }

            return b;
        }

        // private static int ConvertInt32(byte[] b)
        // {
        //     uint ival = 0;
        //     int len = b.Length;
        //     for (int i = 0; i < len; i++)
        //     {
        //         int shift = 8 * (len - 1 - i);
        //         ival = ival | (uint)(b[i] << shift);
        //     }
        //
        //     return (int)ival;
        // }

        // private static int GenerateTime()
        // {
        //     var now = DateTime.UtcNow;
        //     var nowtime = new DateTime(Epoch.Year, Epoch.Month, Epoch.Day,
        //         now.Hour, now.Minute, now.Second, now.Millisecond);
        //     var diff = nowtime - Epoch;
        //     return Convert.ToInt32(Math.Floor(diff.TotalMilliseconds));
        // }

        private static byte[] GenerateHostHash()
        {
            using (var md5 = MD5.Create())
            {
                var host = Dns.GetHostName();
                return HashAlgorithmHelper.ComputeHashByteUTF8<MD5>(host);
                // return md5.ComputeHash(Encoding.Default.GetBytes(host));
            }
        }

        private static int ProcessId()
        {
            var process = Process.GetCurrentProcess();
            return process.Id;
        }

        private static int Counter()
        {
            lock (_innerLock)
            {
                return _counter++;
            }
        }
    }
}