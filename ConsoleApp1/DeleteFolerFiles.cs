using System.IO;

namespace ConsoleApp1
{
    public class DeleteFolerFiles
    {
        /// <summary>
        /// Delete folder and files
        /// </summary>
        public void DeleteFolder()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\GMMQ\Export");
            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo file in directory.GetDirectories())
            {
                file.Delete();
            }
        }
    }
}
