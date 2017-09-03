using System.IO;
using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        #region Export

        static void Export()
        {
            /********************************************************************************
             * Если в каталоге Export есть файл gmmq.packedge.end,
             * тогда перезапускаем службы
             * если файл gmmq.packedge.end отсутсвует, очищаем каталог 
             * и выполняем скрипты на выгрузку реплики 
             *******************************************************************************/

            string pathFileExportG = "C:\\GMMQ\\Export\\gmmq.package.end";

            if (File.Exists(pathFileExportG))
            {
                //TODO: перед релизной сборкой снять комментарий
                ServicesRestart restart = new ServicesRestart();
                restart.RestartGmmq();
                restart.RestartScheduler();
            }
            else
            {
                //Чистм катаоги
                var delete = new DeleteFolerFiles();
                delete.DeleteFolder();

                //Делаем экспорт
                var script = new ExecuteScript();
                script.ScriptExport();

                //спим 5 минут
                Console.WriteLine(DateTime.Now.ToShortDateString() + "Ждем 5 минут");
                Logger.Log.Info("Ждем 5 минут");
                Thread.Sleep(300000);

                //Перезапускаем службы
                ServicesRestart services = new ServicesRestart();
                services.RestartGmmq();
                services.RestartScheduler();
            }
        }

        #endregion

        #region Import

        static void Import()
        {
            /********************************************************************************
            * Если в каталоге Import есть файл gmmq.packedge.end,
            * тогда выполняем скрипт на всасывание реплики
            * если файл gmmq.packedge.end отсутсвует, очищаем каталог 
            *******************************************************************************/

            string pathFileImport = "C:\\GMMQ\\Import\\gmmq.package.end";

            if (File.Exists(pathFileImport))
            {
                //Всасываем реплику
                var script = new ExecuteScript();
                script.ScriptImport();
            }
            else
            {
                //Чистим каталог
                var delete = new DeleteFolerFiles();
                delete.CleanFolderImport();
            }
        }

        #endregion

        static int Main()
        {
            Console.WriteLine(new string('*', 50));
            Console.WriteLine("*                                                *");
            Console.WriteLine("*     Разработано МРЦ Сибирь г. Новосибирск      *");
            Console.WriteLine("*     Keeper                                     *");
            Console.WriteLine("*     v.2.1.3.5                                  *");
            Console.WriteLine("*     Утилита для восстановления                 *");
            Console.WriteLine("*     работоспособности транспорта в ОПС         *");
            Console.WriteLine("*     Шиманов Дмитрий Анатольевич                *");
            Console.WriteLine("*     Email: Dmitriy.Shimanov@russianpost.ru     *");
            Console.WriteLine("*     LICENSE: Apache 2.0                        *");
            Console.WriteLine("*                                                *");
            Console.WriteLine(new string('*', 50));
            Console.Title = "Keeper v.2.1.3.5";
            //Иницилизация log4net
            Logger.InitLogger();

            Export();

            Import();

            return 0;
        }
    }
}

