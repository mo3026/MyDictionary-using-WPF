using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace MyDictionary.Database.SQLCE
{
    class QueryWithClose
    {
        static SqlCeConnection SQLConnection;
        static bool connected = false;

        static void Connect()
        {
            if (SQLConnection==null) SQLConnection = Database.SQLCE.SQLCE.GetSqlCe("Words1", false);
            while(true)
            {
                try
                {
                    SQLConnection.Open();
                    break;
                }
                catch { }
            }
        }

        public static DefinitionCollection RetrieveData()
        {
            if (!connected) Connect();
            SqlCeCommand cmd = new SqlCeCommand();
            cmd.CommandText = "Select * from [Words]";
            cmd.Connection = SQLConnection;
            SqlCeDataReader data_reader = cmd.ExecuteReader();
            DefinitionCollection dc = new DefinitionCollection(Database.ConnectionType.Ce);
            while (data_reader.Read())
            {
                string word = (string)data_reader["Word"];
                string definitionXml = (string)data_reader["Definition"];
                Definition d = new Definition(Database.ConnectionType.Ce);
                System.IO.StringReader ss = new System.IO.StringReader(definitionXml);
                System.Xml.XmlReader x = System.Xml.XmlReader.Create(ss);
                x.Read();
                d.ReadXml(x);
                dc.Add(word, d, false);
            }
            data_reader.Close();
            cmd = new SqlCeCommand();
            cmd.CommandText = "Select * from [Images]";
            cmd.Connection = SQLConnection;
            data_reader = cmd.ExecuteReader();
            Images ic = new Images();
            while (data_reader.Read())
            {
                string word = (string)data_reader["Word"];
                byte[] definitionXml = (byte[])data_reader["Image"];
                dc[word].Images.Add(ImageFromBuffer(definitionXml));
            }
            data_reader.Close();
            SQLConnection.Close();
            return dc;
        }

        public static System.Windows.Media.Imaging.BitmapImage ImageFromBuffer(Byte[] bytes)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream(bytes);
            System.Windows.Media.Imaging.BitmapImage image = new System.Windows.Media.Imaging.BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }

        public static void AddDefinition(string Word, string XMLDefinition)
        {
            if (!connected) Connect();
            string tableWords = "INSERT INTO [Words] Values (@na,@occ);";
            SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.Parameters.AddWithValue("@occ", XMLDefinition);
            command.ExecuteNonQuery();
            SQLConnection.Close();
        }

        public static void RemoveDefinition(string Word)
        {
            if (!connected) Connect();
            string tableWords2 = "DELETE FROM [Images] WHERE Word=@na;";
            SqlCeCommand command2 = new SqlCeCommand(tableWords2, SQLConnection);
            command2.Parameters.AddWithValue("@na", Word);;
            command2.ExecuteNonQuery();
            SQLConnection.Close();

            if (!connected) Connect();
            string tableWords = "DELETE FROM [Words] WHERE Word=@na;";
            SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.ExecuteNonQuery();
            SQLConnection.Close();
        }

        public static void ChangeDefinition(string Word, string XMLDefinition)
        {
            if (!connected) Connect();
            string tableWords = "UPDATE [Words] SET Definition=@occ WHERE Word=@na;";
            SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.Parameters.AddWithValue("@occ", XMLDefinition);
            command.ExecuteNonQuery();
            SQLConnection.Close();
        }

        public static void AddImage(string Word, byte[] Image)
        {
            try
            {
                if (!connected) Connect();
                string tableWords = "INSERT INTO [Images] Values (@na,@occ);";
                SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
                command.Parameters.AddWithValue("@na", Word);
                command.Parameters.AddWithValue("@occ", Image);
                command.ExecuteNonQuery();
                SQLConnection.Close();
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }

        public static void RemoveImage(string Word, byte[] Image)
        {
            if (!connected) Connect();
            string tableWords = "DELETE FROM [Images] WHERE Word=@na;";
            SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.ExecuteNonQuery();
            SQLConnection.Close();
        }

        public static CategoriesCollection RetrieveCats()
        {
            if (!connected) Connect();
            SqlCeCommand cmd = new SqlCeCommand();
            cmd.CommandText = "Select * from [Categories]";
            cmd.Connection = SQLConnection;
            SqlCeDataReader data_reader = cmd.ExecuteReader();
            CategoriesCollection dc = new CategoriesCollection(Database.ConnectionType.Ce);
            while (data_reader.Read())
            {
                string word = (string)data_reader["Category"];
                dc.Add(word, false);
            }
            data_reader.Close();
            SQLConnection.Close();
            return dc;
        }

        public static void AddCat(string Cat)
        {
            if (!connected) Connect();
            string tableWords = "INSERT INTO [Categories] Values (@ca);";
            SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@ca", Cat);
            command.ExecuteNonQuery();
            SQLConnection.Close();
        }

        public static void RemoveCat(string Cat)
        {
            string tableWords = "DELETE FROM [Categories] WHERE Category=@ca;";
            SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@ca", Cat);
            command.ExecuteNonQuery();
            SQLConnection.Close();
        }
    }
}
