using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading;

namespace ConsoleApp1
{
    public class ServiceProcessRestart
    {
        /// <summary>
        /// Restart GMMQ service
        /// </summary>
        public void RestartGmmq()
        {
            ServiceController gmmq = new ServiceController("GMMQ");
            if (gmmq.Status == ServiceControllerStatus.Running)
            {
                gmmq.Stop();
                gmmq.WaitForStatus(ServiceControllerStatus.Stopped);

                gmmq.Start();
                gmmq.WaitForStatus(ServiceControllerStatus.Running);
            }
            else
            {
                gmmq.Start();
                gmmq.WaitForStatus(ServiceControllerStatus.Running);
            }
        }

        /// <summary>
        /// Restart GM_Scheduler process
        /// </summary>
        public void RestartProcess()
        {
            string procName = "GM_Scheduler.exe";
            Process pr = new Process();
            //Получаем список процессов
            Process[] processes = Process.GetProcesses();
            try
            {
                //Находим процесс
                Process process = processes.First(x => x.ProcessName == procName);
                //убиваем процесс
                process.Kill();

                //Спим 10 секунд
                Thread.Sleep(10000);
                //и запускаем процесс
                process.Start();
            }
            catch (Exception)
            {
                //Если процесса нет, тогда запускаем его
                pr.StartInfo.FileName = @"C:\Program Files (x86)\Microsoft Dynamics AX\60\Retail POS\GM_Scheduler.exe";
                pr.Start();
            }
        }
    }
}
