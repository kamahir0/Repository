using System.IO;
using System.Text;

namespace Lilja.Repository
{
    public static class AtomicFileWriter
    {
        public static void WriteAllText(string filePath, string content)
        {
            var tempPath = filePath + ".tmp";
            EnsureDirectory(filePath);
            try
            {
                File.WriteAllText(tempPath, content, new UTF8Encoding(false));
                ReplaceFile(tempPath, filePath);
            }
            finally
            {
                DeleteIfExists(tempPath);
            }
        }

        public static void WriteAllBytes(string filePath, byte[] bytes)
        {
            var tempPath = filePath + ".tmp";
            EnsureDirectory(filePath);
            try
            {
                File.WriteAllBytes(tempPath, bytes);
                ReplaceFile(tempPath, filePath);
            }
            finally
            {
                DeleteIfExists(tempPath);
            }
        }

        public static bool DeleteIfExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            File.Delete(filePath);
            return true;
        }

        private static void ReplaceFile(string tempPath, string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Move(tempPath, filePath);
                return;
            }

            var backupPath = filePath + ".bak";
            DeleteIfExists(backupPath);
            File.Replace(tempPath, filePath, backupPath, true);
            DeleteIfExists(backupPath);
        }

        private static void EnsureDirectory(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
