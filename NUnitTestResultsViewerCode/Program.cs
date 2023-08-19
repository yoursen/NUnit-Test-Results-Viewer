using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NUnitTestResultsViewerCode
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string defaultPath;
            Application.Run(TryGetDefaultPath(out defaultPath) ? new FormMain(defaultPath) : new FormMain());
        }

        private static bool TryGetDefaultPath(out string defaultPath)
        {
            defaultPath = "";

            // Default path
            var cmdArgs = Environment.GetCommandLineArgs();

            if (cmdArgs.Length != 2)
            {
                return false;
            }

            var path = cmdArgs[1];
            if (File.Exists(path))
            {
                defaultPath = path;
                return true;
            }
            return false;
        }
    }
}
