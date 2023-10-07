using System.IO;

namespace ASI.Basecode.Data
{
    /// <summary>
    /// Path Manager
    /// </summary>
    public class PathManager
    {
        /// <summary>
        /// Gets or sets the setup root directory.
        /// </summary>
        public static string SetupRootDirectory { get; set; }

        /// <summary>
        /// Setups the specified setup root directory.
        /// </summary>
        /// <param name="setupRootDirectory">The setup root directory.</param>
        public static void Setup(string setupRootDirectory)
        {
            SetupRootDirectory = setupRootDirectory;
        }

        /// <summary>
        /// Directory Path
        /// </summary>
        public static class DirectoryPath
        {
            /// <summary>
            /// Log file storage directory path
            /// </summary>
            public static string LogDirectory
            {
                get { return GetFolderPath(SetupRootDirectory, "logs"); }
            }

            /// <summary>
            /// application log directory path
            /// </summary>
            /// <param name="appName">application name</param>
            /// <returns>directory path</returns>
            public static string ApplicationLogsDirectory(string appName)
            {
                return GetFolderPath(Path.Combine(LogDirectory, appName));
            }
        }

        /// <summary>
        /// File Path
        /// </summary>
        public static class FilePath
        {
        }

        /// <summary>
        /// Gets the folder path and create the directory
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="folderName">Name of the folder.</param>
        /// <returns>Directory path</returns>
        private static string GetFolderPath(string path, string folderName = "")
        {
            string result = Path.Combine(path, folderName);
            if (!Directory.Exists(result))
            {
                Directory.CreateDirectory(result);
            }

            return result;
        }
    }
}
