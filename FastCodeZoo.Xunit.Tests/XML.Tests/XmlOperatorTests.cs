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