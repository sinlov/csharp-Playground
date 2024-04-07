using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FastCodeZoo.XML;
using Xunit;
using Xunit.Abstractions;

namespace FastCodeZoo.XMK.Tests
{
    public class XmlOperatorTests : BaseTests.BaseTests
    {
        private const string _defaultXMLContant = @"<?xml version=""1.0"" encoding=""utf-8""?>
<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd""[]>
<plist version=""1.0"">
  <dict>
    <key>aps-environment</key>
    <string>development</string>
    <key>com.apple.developer.applesignin</key>
    <key>com.apple.developer.applesignin</key>
    <key>com.apple.developer.applesignin</key>
    <key>com.apple.developer.applesignin</key>
    <key>com.apple.developer.applesignin</key>
    <key>com.apple.developer.applesignin</key>
    <key>com.apple.developer.applesignin</key>
    <key>com.apple.developer.applesignin</key>
    <key>com.apple.developer.applesignin</key>
    <key>com.apple.developer.applesignin</key>
  </dict>
</plist>
";

        private string _defaultXML;
        private string _errorXML;
        private string _rootXPath;
        private string _targetXPath;
        private string _injectElement;
        private List<string> _attributes;

        public XmlOperatorTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            InitSelf(MethodBase.GetCurrentMethod());
            _defaultXML = Path.Combine(GetCurSourceFileAbsDir, "default.xml");
            _errorXML = Path.Combine(GetCurSourceFileAbsDir, "error.json");
            _rootXPath = "plist";
            _targetXPath = "dict";
            _injectElement = "key";
            _attributes = new List<string>();
            _attributes.Add("com.apple.developer.applesignin");
            if (!File.Exists(_defaultXML))
            {
                File.WriteAllText(_defaultXML, _defaultXMLContant);
            }
        }

        [Fact]
        public void Test_InjectElementWithTexts_ErrorPath()
        {
            Exception withAttributes =
                XmlOperator.InjectElementWithTexts("", _rootXPath, _targetXPath, _injectElement, _attributes);
            Assert.NotNull(withAttributes);
            TLogException(withAttributes);
        }

        [Fact]
        public void Test_InjectElementWithTexts_ErrorFileType()
        {
            Exception withAttributes =
                XmlOperator.InjectElementWithTexts(_errorXML, _rootXPath, _targetXPath, _injectElement,
                    _attributes);
            Assert.NotNull(withAttributes);
            TLogException(withAttributes);
        }

        [Fact]
        public void Test_InjectElementWithTexts()
        {
            DirectoryInfo dir = new DirectoryInfo(GetCurSourceFileAbsDir);
            if (!dir.Exists)
            {
                TLog($"GetCurSourceFileAbsDir not exist at: {GetCurSourceFileAbsDir}");
            }
            else
            {
                TLog($"GetCurSourceFileAbsDir exist at: {GetCurSourceFileAbsDir}");
            }

            Exception withAttributes =
                XmlOperator.InjectElementWithTexts(_defaultXML, _rootXPath, _targetXPath, _injectElement,
                    _attributes);
            if (withAttributes != null)
            {
                TLogException(withAttributes);
            }

            Assert.Null(withAttributes);
        }


        public static string GetCurSourceFileAbsPath
        {
            get
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1, true);
                return st.GetFrame(0).GetFileName();
            }
        }

        public static string GetCurSourceFileAbsDir
        {
            get { return Path.GetDirectoryName(GetCurSourceFileAbsPath); }
        }
    }
}