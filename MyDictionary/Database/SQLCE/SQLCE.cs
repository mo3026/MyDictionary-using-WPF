using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlServerCe;
using System.Reflection;

namespace MyDictionary.Database.SQLCE
{
    class SQLCE
    {
        //public const string DB_DIRECTORY = "Data";

        public static System.Data.SqlServerCe.SqlCeConnection GetSqlCe(string dbName, bool deleteIfExists = false)
        {
            //try
            {
                string outputFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string mdfFilename = dbName + ".sdf";
                string dbFileName = Path.Combine(outputFolder, mdfFilename);
                //string logFileName = Path.Combine(outputFolder, String.Format("{0}_log.ldf", dbName));
                // Create Data Directory If It Doesn't Already Exist.
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                // If the file exists, and we want to delete old data, remove it here and create a new database.
                if (File.Exists(dbFileName) && deleteIfExists)
                {
                    //if (File.Exists(logFileName)) File.Delete(logFileName);
                    File.Delete(dbFileName);
                    //System.Windows.MessageBox.Show("");
                    CreateDatabase(dbName, dbFileName);
                }
                // If the database does not already exist, create it.
                else if (!File.Exists(dbFileName))
                {
                    //System.Windows.MessageBox.Show("");
                    CreateDatabase(dbName, dbFileName);
                }

                // Open newly created, or old database.
                string connectionString = String.Format(@"DataSource={1}", dbName, dbFileName);
                SqlCeConnection connection = new SqlCeConnection(connectionString);
                connection.Open();
                return connection;
            }
            /*catch
            {
                throw;
            }*/
        }

        static bool CreateDatabase(string dbName, string dbFileName)
        {
            //try
            {
                string connectionString = string.Format(@"DataSource={0}", dbFileName);
                SqlCeEngine engine = new SqlCeEngine(connectionString);
                engine.CreateDatabase();

                using (var connection = new System.Data.SqlServerCe.SqlCeConnection(connectionString))
                {
                    //connection.Open();
                    //SqlCeCommand cmd = connection.CreateCommand();


                    //DetachDatabase(dbName, dbFileName);

                    //cmd.CommandText = String.Format("CREATE DATABASE {0} ON (NAME = N'{0}', FILENAME = '{1}')", dbName, dbFileName);
                    //cmd.ExecuteNonQuery();

                    //engine.CreateDatabase();

                    //connection.Close();
                    //connectionString = String.Format(@"DataSource={1};AttachDBFileName={1};Initial Catalog={0};", dbName, dbFileName);
                    //connection.ConnectionString = connectionString;
                    connection.Open();
                    CreateTables(connection);
                }

                if (File.Exists(dbFileName)) return true;
                else return false;
            }
            /*catch
            {
                throw;
            }*/
        }

        static void CreateTables(SqlCeConnection connection)
        {
            string tableCats = "CREATE TABLE Categories ( Category nvarchar(500) not null primary key);";
            string tableWords = "CREATE TABLE Words ( Word nvarchar(500) not null primary key, Definition ntext);";
            string tableImages = "CREATE TABLE Images ( ID int IDENTITY(1,1) PRIMARY KEY, Word nvarchar(500), Image image, FOREIGN KEY (Word) REFERENCES Words(Word) );";
            SqlCeCommand command = new SqlCeCommand(tableWords, connection);
            command.ExecuteNonQuery();
            command.CommandText = tableImages;
            command.ExecuteNonQuery();
            command.CommandText = tableCats;
            command.ExecuteNonQuery();
        }
    }
}
