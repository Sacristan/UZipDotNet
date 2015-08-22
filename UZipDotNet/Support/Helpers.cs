using System.Collections;
using System.IO;

namespace UZipDotNet.Support
{
    public class Helpers
    {
        public static void CompressDirectory(string directoryPath, string archivePath, string archiveName, bool deleteDirectory=false)
        {
            string archivefile = Path.Combine(archivePath, archiveName);
            Directory.CreateDirectory(archivePath);

            string[] files = Directory.GetFiles(directoryPath);

            using (var def = new UZipDotNet.DeflateZipFile(@archivefile))
            {
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    def.Compress(file, fileName);
                }
                def.Save();
            }

            if(deleteDirectory)
                Directory.Delete(directoryPath, true);
        }

        public static void DecompressDirectory(string filePath, string decompressPath)
        {
            using(var inf = new UZipDotNet.InflateZipFile(@filePath))
            {
                inf.DecompressAll(decompressPath, true);
            }
        }

    }
}
