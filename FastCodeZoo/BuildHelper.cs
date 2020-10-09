using System;
using System.IO;
using System.Reflection;

namespace FastCodeZoo
{
    public struct BuildConfigInfo
    {
        public string Name;
        public string NameSpace;
        public string VersionName;
        public int VersionCode;
        public long BuildTime;
    }

    public class BuildHelper
    {
        public static BuildConfigInfo FetchBuildConfig(string namespaceZoo)
        {
            BuildConfigInfo buildConfigInfo = new BuildConfigInfo();
            string runPath = AppDomain.CurrentDomain.BaseDirectory;
            string assemblyPath = Path.Combine(runPath, $"{namespaceZoo}.dll");
            var assembly = Assembly.UnsafeLoadFrom(assemblyPath);
            Type type = assembly.GetType($"{namespaceZoo}.BuildConfig");
            var fieldInfos = type.GetFields(
                // BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy
            );
            foreach (var fieldInfo in fieldInfos)
            {
                if (fieldInfo.Name == "Name")
                {
                    string val = (string) fieldInfo.GetRawConstantValue();
                    buildConfigInfo.Name = val;
                }

                if (fieldInfo.Name == "NameSpace")
                {
                    string val = (string) fieldInfo.GetRawConstantValue();
                    buildConfigInfo.NameSpace = val;
                }

                if (fieldInfo.Name == "VersionName")
                {
                    string val = (string) fieldInfo.GetRawConstantValue();
                    buildConfigInfo.VersionName = val;
                }

                if (fieldInfo.Name == "VersionCode")
                {
                    var val = (int) fieldInfo.GetRawConstantValue();
                    buildConfigInfo.VersionCode = val;
                }

                if (fieldInfo.Name == "BuildTime")
                {
                    var val = (long) fieldInfo.GetRawConstantValue();
                    buildConfigInfo.BuildTime = val;
                }
            }

            return buildConfigInfo;
        }
    }
}