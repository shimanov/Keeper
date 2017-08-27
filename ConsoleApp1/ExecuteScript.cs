using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    public class ExecuteScript
    {
        /// <summary>
        /// Execute script
        /// </summary>
        public void ScriptExport()
        {
            //Получаем имя ПК
            string namePc = Environment.MachineName.ToLower();
            //Обраем лишнее и получаем индекс
            namePc = namePc.Trim(new char[]
            {
                'r', '5', '4', '-', '-', 'n'
            });
            string dataBaseName = "DB" + namePc;

            //Подключаемся к БД
            SqlConnection connection = new SqlConnection("Server = localhost; " 
                + "Initial Catalog = " + dataBaseName + ";" 
                + "Integrated Security = SSPI");
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandText = "use " +dataBaseName + " exec ReplicaExport 0";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = connection;
            connection.Open();
            reader = sqlCommand.ExecuteReader();
            connection.Close();
        }

        /// <summary>
        /// Смещение времени шедулера
        /// </summary>
        public void ScriptOffset()
        {
            //Получаем имя ПК
            string namePc = Environment.MachineName.ToLower();
            //Обраем лишнее и получаем индекс
            namePc = namePc.Trim(new char[]
            {
                'r', '5', '4', '-', '-', 'n'
            });
            string dataBaseName = "DB" + namePc;

            //Подключаемся к БД
            SqlConnection connection = new SqlConnection("Server = localhost; "
                + "Initial Catalog = " + dataBaseName + ";"
                + "Integrated Security = SSPI");
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandText = "use " + dataBaseName 
                + " declare @increment int = 3\r\nbegin tran\r\nif(1 = (select 1 from GM_POSSchedJobTable where status = 0 and taskId = \'Репликация\'))\r\nbegin\r\n       update GM_POSSchedJobTable set StartDateTimeScheduled = dateAdd(mi, @increment, getdate()) where status = 0 and taskId = \'Репликация\'\r\n       select \'Время старта репликации изменено на \' + convert(nvarchar(60), dateAdd(mi, @increment, getdate()), 20)\r\n       commit tran\r\nend\r\nelse\r\nif(1=(select 1 from GM_POSSchedJobTable where status = 1 and taskId = \'Репликация\'))\r\nbegin\r\n       select \'Задание репликации находится в процессе выполнения. Повторите попытку через пару минут.\'\r\n       rollback tran\r\nend\r\nelse\r\nbegin\r\n       select \'Задание репликации отсутствует. Обратитесь к администратору.\'\r\n       rollback tran\r\nend";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = connection;
            connection.Open();
            reader = sqlCommand.ExecuteReader();
            connection.Close();
        }   
    }
}
