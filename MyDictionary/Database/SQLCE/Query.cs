using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace MyDictionary.Database.SQLCE
{
    class Query
    {
        static SqlCeConnection SQLConnection;
        static bool connected = false;

        static void Connect()
        {
            SQLConnection = Database.SQLCE.SQLCE.GetSqlCe("Words", false);
            connected = true;
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
                int ID = (int)data_reader["ID"];
                string word = (string)data_reader["Word"];
                byte[] definitionXml = (byte[])data_reader["Image"];
                System.Windows.Media.Imaging.BitmapImage bi = ImageFromBuffer(definitionXml);
                dc[word].Images.Add(bi);
                dc[word].Images.Indexes.Add(bi, ID);
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
            SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.Parameters.AddWithValue("@occ", XMLDefinition);
            command.ExecuteNonQuery();
        }

        public static void RemoveDefinition(string Word)
        {
            if (!connected) Connect();
            string tableWords2 = "DELETE FROM [Images] WHERE Word=@na;";
            SqlCeCommand command2 = new SqlCeCommand(tableWords2, SQLConnection);
            command2.Parameters.AddWithValue("@na", Word);;
            command2.ExecuteNonQuery();

            if (!connected) Connect();
            string tableWords = "DELETE FROM [Words] WHERE Word=@na;";
            SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.ExecuteNonQuery();
        }

        public static void ChangeDefinition(string Word, string XMLDefinition)
        {
            if (!connected) Connect();
            string tableWords = "UPDATE [Words] SET Definition=@occ WHERE Word=@na;";
            SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.Parameters.AddWithValue("@occ", XMLDefinition);
            command.ExecuteNonQuery();
        }

        public static int AddImage(string Word, byte[] Image)
        {
            if (!connected) Connect();
            string tableWords = "INSERT INTO [Images]( Word, Image) Values (@na,@occ);";
            SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.Parameters.Add("@occ", System.Data.SqlDbType.Image, Image.Length).Value = Image;
            command.ExecuteNonQuery();
            command.CommandText = "SELECT @@IDENTITY";
            var id = command.ExecuteScalar();
            return (int)id;
        }

        public static void RemoveImage(string Word, int Index)
        {
            if (!connected) Connect();
            string tableWords = "DELETE FROM [Images] WHERE Word=@na AND ID=@occ;";
            SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@na", Word);
            command.Parameters.AddWithValue("@occ", Index);
            command.ExecuteNonQuery();
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
            return dc;
        }

        public static void AddCat(string Cat)
        {
            if (!connected) Connect();
            string tableWords = "INSERT INTO [Categories] Values (@ca);";
            SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@ca", Cat);
            command.ExecuteNonQuery();
        }

        public static void RemoveCat(string Cat)
        {
            if (!connected) Connect();
            string tableWords = "DELETE FROM [Categories] WHERE Category=@ca;";
            SqlCeCommand command = new SqlCeCommand(tableWords, SQLConnection);
            command.Parameters.AddWithValue("@ca", Cat);
            command.ExecuteNonQuery();
        }
    }
}
