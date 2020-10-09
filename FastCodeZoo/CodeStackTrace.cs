using System.IO;

namespace FastCodeZoo
{
    public static class CodeStackTrace
    {
        public static string GetProgramRunnerDir
        {
            get
            {
                var editorPath = System.Environment.GetCommandLineArgs()[0];
                var editorDir = Path.GetDirectoryName(editorPath);
                return editorDir;
            }
        }

        public static string GetCurSourceFileName
        {
            get
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1, true);
                return st.GetFrame(0).GetFileName();
            }
        }
    }
}