using System;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.EndianBitConverter.Test
{
    public class GetBytesTests : BaseTests.BaseTests
    {
        private static EndianBitConverter machineEndianBitConverter;
        private static EndianBitConverter otherEndianBitConverter;

        [Fact]
        public void GetBytesFromBool()
        {
            // don't use System.BitConverter as an oracle for boolean true, as it can theoretically map to any non-zero byte
            Assert.Equal(new byte[] { 0x01 }, EndianBitConverter.BigEndian.GetBytes(true));
            Assert.Equal(new byte[] { 0x01 }, EndianBitConverter.LittleEndian.GetBytes(true));

            // compare to System.BitConverter
            // AssertGetBytesResult(BitConverter.GetBytes, machineEndianBitConverter.GetBytes, otherEndianBitConverter.GetBytes, false);
        }


        public GetBytesTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
            if (BitConverter.IsLittleEndian)
            {
                machineEndianBitConverter = EndianBitConverter.LittleEndian;
                otherEndianBitConverter = EndianBitConverter.BigEndian;
            }
            else
            {
                machineEndianBitConverter = EndianBitConverter.BigEndian;
                otherEndianBitConverter = EndianBitConverter.LittleEndian;
            }
        }
    }
}