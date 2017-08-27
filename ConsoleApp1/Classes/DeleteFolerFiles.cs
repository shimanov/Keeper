using System.IO;
using ConsoleApp1.Base;
using System;

namespace ConsoleApp1
{
    /// <summary>
    /// Класс очистки каталогов Import и Export
    /// </summary>
    public class DeleteFolerFiles : IDeleteFolderFiles
    {
        /// <summary>
        /// Очистка каталога Export
        /// </summary>
        public void DeleteFolder()
        {
            string deleteExportPath = @"C:\GMMQ\Export";
            DeleteFolder(deleteExportPath);
            Console.WriteLine("Каталог Export очищен");
        }

        /// <summary>
        /// Очистка каталога Import
        /// </summary>
        /// <returns></returns>
        public void CleanFolderImport()
        {
            string deleteExportPath = @"C:\GMMQ\Import";
            DeleteFolder(deleteExportPath);
            Console.WriteLine("Каталог Import очищен");
        }

        static void DeleteFolder(string folder)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(folder);

                //Создаем массив дочерних вложенных каталогов folder
                DirectoryInfo[] directoryInfos = directory.GetDirectories();
                FileInfo[] file = directory.GetFiles();
                foreach (FileInfo f in file)
                {
                    f.Delete();
                }

                foreach (DirectoryInfo d in directoryInfos)
                {
                    DeleteFolder(d.FullName);

                    if (d.GetDirectories().Length == 0 && d.GetFiles().Length == 0)
                    {
                        d.Delete();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Logger.Log.Error(e.ToString());
            }
        }
    }
}
