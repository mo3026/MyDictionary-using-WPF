using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace MyDictionary.Database.LocalDB
{
    class Query
    {
        static SqlConnection SQLConnection;
        static bool connected = false;

        static void Connect()
        {
            SQLConnection = Database.LocalDB.LocalDB.GetLocalDB("Words", false);
            //Database.LocalDB.LocalDB.CreateTables(SQLConnection);
            connected = true;
        }

        public static DefinitionCollection RetrieveData()
        {
            if (!connected) Connect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from [Words]";
            cmd.Connection = SQLConnection; 
            SqlDataReader data_reader = cmd.ExecuteReader();
            DefinitionCollection dc = new DefinitionCollection(Database.ConnectionType.LocalDB);
            while (data_reader.Read())
            {
                string word = (string)data_reader["Word"];
                string definitionXml = (string)data_reader["Definition"];
                Definition d = new Definition(Database.ConnectionType.LocalDB);
                System.IO.StringReader ss = new System.IO.StringReader(definitionXml);
                System.Xml.XmlReader x = System.Xml.XmlReader.Create(ss);
                x.Read();
                d.ReadXml(x);
                dc.Add(word, d, false);
            }
            data_reader.Close();
            cmd = new SqlCommand();
            cmd.CommandText = "Select * from [Images]";
            cmd.Connection = SQLConnection;
            data_reader = cmd.ExecuteReader();
            Images ic = new Images();
            while (data_reader.Read())
            {
                int ID = (int)data_reader["ID"];
                string word = (string)data_reader["Word"];
                byte[] definitionXml = (byte[])data_reader["Image"];
                dc[word].Images.Add(ImageFromBuffer(definitionXml));
            }
            data_reader.Close();
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
            SqlCommand command = new SqlCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.Parameters.AddWithValue("@occ", XMLDefinition);
            command.ExecuteNonQuery();
        }

        public static void RemoveDefinition(string Word)
        {
            if (!connected) Connect();
            string tableWords2 = "DELETE FROM [Images] WHERE Word=@na;";
            SqlCommand command2 = new SqlCommand(tableWords2, SQLConnection);
            command2.Parameters.AddWithValue("@na", Word);
            command2.ExecuteNonQuery();

            if (!connected) Connect();
            string tableWords = "DELETE FROM [Words] WHERE Word=@na;";
            SqlCommand command = new SqlCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.ExecuteNonQuery();
        }

        public static void ChangeDefinition(string Word, string XMLDefinition)
        {
            if (!connected) Connect();
            string tableWords = "UPDATE [Words] SET Definition=@occ WHERE Word=@na;";
            SqlCommand command = new SqlCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.Parameters.AddWithValue("@occ", XMLDefinition);
            command.ExecuteNonQuery();
        }

        public static void AddImage(string Word, byte[] Image)
        {
            if (!connected) Connect();
            string tableWords = "INSERT INTO [Images] Values (@na,@occ);";
            SqlCommand command = new SqlCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.Parameters.AddWithValue("@occ", Image);
            command.ExecuteNonQuery();
        }

        public static void RemoveImage(string Word, byte[] Image)
        {
            if (!connected) Connect();
            string tableWords = "DELETE FROM [Images] WHERE Word=@na AND Image=@occ;";
            SqlCommand command = new SqlCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.Parameters.AddWithValue("@occ", Image);
            command.ExecuteNonQuery();
        }

        public static CategoriesCollection RetrieveCats()
        {
            if (!connected) Connect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from [Categories]";
            cmd.Connection = SQLConnection;
            SqlDataReader data_reader = cmd.ExecuteReader();
            CategoriesCollection dc = new CategoriesCollection(Database.ConnectionType.LocalDB);
            while (data_reader.Read())
            {
                string word = (string)data_reader["Category"];
                dc.Add(word, false);
            }
            data_reader.Close();
            return dc;
        }

        public static void AddCat(string Cat)
        {
            if (!connected) Connect();
            string tableWords = "INSERT INTO [Categories] Values (@ca);";
            SqlCommand command = new SqlCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@ca", Cat);
            command.ExecuteNonQuery();
        }

        public static void RemoveCat(string Cat)
        {
            if (!connected) Connect();
            string tableWords = "DELETE FROM [Categories] WHERE Category=@ca;";
            SqlCommand command = new SqlCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@ca", Cat);
            command.ExecuteNonQuery();
        }
    }
}
