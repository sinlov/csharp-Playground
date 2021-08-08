using System;
using System.Text;

namespace FastCodeZoo.HexCode
{
    public static class HexCodeUtil
    {
        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4CAB2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with out spacing. </returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
            {
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            }

            return sb.ToString().ToUpper();
        }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        public static string ByteArrayToHexStringWithSpace(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
            {
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            }

            return sb.ToString().ToUpper();
        }

        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
            {
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            }

            return buffer;
        }

        /// <summary>
        /// Converts a hexadecimal string to ASCII
        /// </summary>
        /// <param name="hexStr">hexadecimal string</param>
        /// <returns>ASCII</returns>
        public static string HexStringToAscii(string hexStr)
        {
            byte[] bt = HexStringToBinary(hexStr);
            string lin = "";
            for (int i = 0; i < bt.Length; i++)
            {
                lin = lin + bt[i] + " ";
            }


            string[] ss = lin.Trim().Split(new char[] { ' ' });
            char[] c = new char[ss.Length];
            int a;
            for (int i = 0; i < c.Length; i++)
            {
                a = Convert.ToInt32(ss[i]);
                c[i] = Convert.ToChar(a);
            }

            string b = new string(c);
            return b;
        }

        /// <summary>
        /// out string Hex, Split hexadecimal string with Spaces
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>string Hex split with spaces</returns>
        public static string StringToHexArray(string input)
        {
            char[] values = input.ToCharArray();
            StringBuilder sb = new StringBuilder(input.Length * 3);
            foreach (char letter in values)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form.
                // string hexOutput = String.Format("{0:X}", value);
                sb.Append(Convert.ToString(value, 16).PadLeft(2, '0').PadRight(3, ' '));
            }

            return sb.ToString().ToUpper().Trim();
        }


        /// <summary>
        /// Convert hexadecimal string to binary array
        /// </summary>
        /// <param name="hexStr">Split hexadecimal string with Spaces</param>
        /// <returns>string as byte[]</returns>
        public static byte[] HexStringToBinary(string hexStr)
        {
            string[] tmpArr = hexStr.Trim().Split(' ');
            byte[] buff = new byte[tmpArr.Length];
            for (int i = 0; i < buff.Length; i++)
            {
                buff[i] = Convert.ToByte(tmpArr[i], 16);
            }

            return buff;
        }

        /// <summary>
        /// byte to string
        /// </summary>
        /// <param name="arrInput">byte[]</param>
        /// <returns>string</returns>
        public static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sb = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sb.Append(arrInput[i].ToString("X2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Unpack the received data, Unpack the received byte array into a Unicode string
        /// </summary>
        /// <param name="recBytes">byte[]</param>
        /// <returns>Unicode string</returns>
        public static string DisPackage(byte[] recBytes)
        {
            string temp = "";
            foreach (byte b in recBytes)
                temp += b.ToString("X2") + " "; //ToString("X2") string format control in C#
            return temp;
        }

        /// <summary>
        /// int to byte[]
        /// <br/>
        /// This method converts an int type of data into byte[] form,
        /// because int is 32bit and byte is 8bit, so when the type conversion is performed,
        /// only the low 8 bits are obtained and the high 24 bits are discarded.
        /// <br/>
        /// By shifting, the 32-bit data is converted into four 8-bit data.
        /// Note &0xff, in this, &0xff is simply understood as a pair of scissors, which cuts out the 8-bit data you want to get.
        /// </summary>
        /// <param name="i">int number</param>
        /// <returns>byte[]</returns>
        public static byte[] Int2ByteArray(int i)
        {
            byte[] result = new byte[4];
            result[0] = (byte)((i >> 24) & 0xFF);
            result[1] = (byte)((i >> 16) & 0xFF);
            result[2] = (byte)((i >> 8) & 0xFF);
            result[3] = (byte)(i & 0xFF);
            return result;
        }

        /// <summary>
        /// byte[] to Int
        /// <br/>
        /// Convert an int to byte[], but when parsing, you need to restore the data.
        /// <br/>
        /// The same way of shifting is used to restore the appropriate number of bits.
        /// <br/>
        /// 0xFF is hexadecimal data, so adding one bit afterwards is equivalent to adding 4 bits in binary.
        /// <br/>
        /// At the same time, use the |= sign to splice the data and restore it to the final int data.
        /// </summary>
        /// <param name="bytes">byte[]</param>
        /// <returns>int</returns>
        public static int Bytes2Int(byte[] bytes)
        {
            int num = bytes[3] & 0xFF;
            num |= ((bytes[2] << 8) & 0xFF00);
            num |= ((bytes[1] << 16) & 0xFF0000);
            num |= ((bytes[0] << 24) & 0xFF0000);
            return num;
        }

        public static string Int2String(int str)
        {
            return Convert.ToString(str);
        }

        public static int String2Int(string str)
        {
            int.TryParse(str, out _);
            int o = Convert.ToInt32(str);
            return o;
        }

        /// <summary>
        /// Convert int to a byte array with low byte first and high byte first
        /// <br/>
        /// b[0] = 11111111(0xff) & 01100001
        /// <br/>
        /// b[1] = 11111111(0xff) & 00000000
        /// <br/>
        /// b[2] = 11111111(0xff) & 00000000
        /// <br/>
        /// b[3] = 11111111(0xff) & 00000000
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] IntToByteArray2(int value)
        {
            byte[] src = new byte[4];
            src[0] = (byte)((value >> 24) & 0xFF);
            src[1] = (byte)((value >> 16) & 0xFF);
            src[2] = (byte)((value >> 8) & 0xFF);
            src[3] = (byte)(value & 0xFF);
            return src;
        }

        /// <summary>
        /// Convert the high byte in the front to int, and the low byte in the byte array (corresponding to IntToByteArray2)
        /// </summary>
        /// <param name="bArr"></param>
        /// <returns></returns>
        public static int ByteArrayToInt2(byte[] bArr)
        {
            if (bArr.Length != 4)
            {
                return -1;
            }

            return (int)((((bArr[0] & 0xff) << 24)
                          | ((bArr[1] & 0xff) << 16)
                          | ((bArr[2] & 0xff) << 8)
                          | ((bArr[3] & 0xff) << 0)));
        }
    }
}