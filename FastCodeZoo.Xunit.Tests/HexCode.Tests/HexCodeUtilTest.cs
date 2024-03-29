using System;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.HexCode.Tests
{
    public class HexCodeUtilTest : BaseTests.BaseTests
    {
        [Fact]
        public void Test_StringToHexArray()
        {
            string hexCode = HexCodeUtil.StringToHexArray("12345qwert");
            TLog($"hexCode: {hexCode}");
            Assert.Equal("31 32 33 34 35 71 77 65 72 74", hexCode);
        }

        [Fact]
        public void Test_HexStringToByteArray()
        {
            byte[] dataByte = HexCodeUtil.HexStringToByteArray("31323334357177657274");
            TLog($"dataByte: {dataByte.Length}");
            Assert.Equal(System.Text.Encoding.Default.GetBytes("12345qwert"), dataByte);
        }

        [Fact]
        public void Test_ByteArrayToHexString()
        {
            byte[] data = System.Text.Encoding.Default.GetBytes("12345qwert");
            string dataStr = HexCodeUtil.ByteArrayToHexString(data);
            Assert.Equal("31323334357177657274", dataStr);
        }

        [Fact]
        public void Test_EndChat()
        {
            byte[] endCharByte = HexCodeUtil.HexStringToBinary("0a");
            TLog($"endChar {Convert.ToString(endCharByte)} Length {endCharByte.Length}");
            // byte[] endCharByte = Encoding.UTF8.GetBytes(EndChar);
            string endChatHex = HexCodeUtil.ByteArrayToHexString(Encoding.UTF8.GetBytes("\n"));
            TLog($"endChatHex {endChatHex}");
        }

        /// <summary>
        /// 终止判断符
        /// </summary>
        public string EndChar
        {
            get { return new string((char)0, 1); }
        }

        public HexCodeUtilTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
        }
    }
}