using System.IO;

namespace QuickStartMenu.Extensions
{
    public static class FileInfoExtensions
    {
        public static string GetFileNameWithoutExtension(this FileInfo fileInfo) 
            => fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length);
    }
}
