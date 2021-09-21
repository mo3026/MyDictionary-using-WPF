using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MyDictionary
{
    public class Definition : System.ComponentModel.INotifyPropertyChanged, System.Xml.Serialization.IXmlSerializable
    {
        string word;
        string meaning;
        string synonym;
        string antonym;
        string example;
        string category;
        Hardness hardness;
        Images images;
        Database.ConnectionType connectionType;

        public Definition(Database.ConnectionType CT)
        {
            category = "Not Categorized";
            hardness = Hardness.Indefinite;
            images = new Images();
            connectionType = CT;
        }
        public Definition(string Word, string Category, Hardness Hardness, Database.ConnectionType CT)
        {
            word = Word;
            category = Category;
            hardness = Hardness;
            images = new Images();
            connectionType = CT;
        }
        public string Word
        {
            get { return word; }
            set
            {
                word = value;
                if (PropertyChanged != null) PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Word"));
            }
        }

        public string Meaning
        {
            get { return meaning; }
            set
            {
                meaning = value;
                if (PropertyChanged != null) PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Meaning"));
                Change();
            }
        }

        private void Change()
        {
            StringBuilder s = new StringBuilder();
            System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            System.Xml.XmlWriter x = System.Xml.XmlWriter.Create(s, settings);
            x.WriteStartElement("Definition");
            this.WriteXml(x);
            x.WriteEndElement();
            x.Flush();
            if (connectionType == Database.ConnectionType.LocalDB) Database.LocalDB.Query.ChangeDefinition(Word, s.ToString());
            else Database.SQLCE.Query.ChangeDefinition(Word, s.ToString());
        }

        public string Synonym
        {
            get { return synonym; }
            set
            {
                synonym = value;
                if (PropertyChanged != null) PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Synonym"));
                Change();
            }
        }

        public string Antonym
        {
            get { return antonym; }
            set
            {
                antonym = value;
                if (PropertyChanged != null) PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Antonym"));
                Change();
            }
        }

        public string Example
        {
            get { return example; }
            set
            {
                example = value;
                if (PropertyChanged != null) PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Example"));
                Change();
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                if (PropertyChanged != null) PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Category"));
                Change();
            }
        }

        public Hardness Hardness
        {
            get { return hardness; }
            set
            {
                hardness = value;
                if (PropertyChanged != null) PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Hardness"));
                Change();
            }
        }

        public Images Images
        {
            get { return images; }
            set
            {
                images = value;
                if (PropertyChanged != null) PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Images"));
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventArgs args = new System.ComponentModel.PropertyChangedEventArgs(propertyName);
            PropertyChanged(this, args);
            if (PropertyChanged != null) PropertyChanged(this, args);
        }

        
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(string));
            XmlSerializer eSerializer = new XmlSerializer(typeof(Hardness));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(Images));
            reader.Read();
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                try
                {
                    switch (reader.Name)
                    {
                        case "Word": this.word = reader.ReadElementContentAsString();
                            break;
                        case "Meaning": this.meaning = reader.ReadElementContentAsString();
                            break;
                        case "Synonym": this.synonym = reader.ReadElementContentAsString();
                            break;
                        case "Antonym": this.antonym = reader.ReadElementContentAsString();
                            break;
                        case "Example": this.example = reader.ReadElementContentAsString();
                            break;
                        case "Category": this.category = reader.ReadElementContentAsString();

                            break;
                        case "Hardness": string s = reader.ReadElementContentAsString();
                            this.hardness = (Hardness)Enum.Parse(typeof(Hardness), s);
                            break;
                        case "Images": this.images = (Images)valueSerializer.Deserialize(reader);
                            break;
                    }
                }
                catch(Exception er)
                {
                    System.Windows.MessageBox.Show(this.word+" message: "+er.Message + " source: " + er.Source + " ine: " + er.InnerException + " data: " + er.Data);
                }
            }
            reader.ReadEndElement();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer eSerializer = new XmlSerializer(typeof(Hardness));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(Images));
            if(this.word!="")
            {
                writer.WriteStartElement("Word");
                writer.WriteString(this.word);
                writer.WriteEndElement();
            }
            if (this.meaning != "" && this.meaning!=null)
            {
                writer.WriteStartElement("Meaning");
                writer.WriteString(this.meaning);
                writer.WriteEndElement();
            }
            if (this.synonym != "" && this.synonym!= null)
            {
                writer.WriteStartElement("Synonym");
                writer.WriteString(this.synonym);
                writer.WriteEndElement();
            }
            if (this.antonym != "" && this.antonym != null)
            {
                writer.WriteStartElement("Antonym");
                writer.WriteString(this.antonym);
                writer.WriteEndElement();
            }
            if (this.example != "" && this.example != null)
            {
                writer.WriteStartElement("Example");
                writer.WriteString(this.example);
                writer.WriteEndElement();
            }
            if (this.category != "" && this.category != null && this.category != "Not Categorized")
            {
                writer.WriteStartElement("Category");
                writer.WriteString(this.category);
                writer.WriteEndElement();
            }
            if (this.hardness != MyDictionary.Hardness.Indefinite)
            {
                eSerializer.Serialize(writer, this.hardness);
            }
        }
        #endregion
    }

    public class Images : System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Imaging.BitmapImage>, System.Xml.Serialization.IXmlSerializable
    {
        public Dictionary<System.Windows.Media.Imaging.BitmapImage,int> Indexes = new Dictionary<System.Windows.Media.Imaging.BitmapImage, int>();

        public void Add(string Word, System.Windows.Media.Imaging.BitmapImage bi)
        {
            this.Add(bi);
            byte[] bitmapData = ((MemoryStream)bi.StreamSource).ToArray();
            int index= Database.SQLCE.Query.AddImage(Word, bitmapData);
            Indexes.Add(bi,index);
        }

        public void Remove(string Word, System.Windows.Media.Imaging.BitmapImage bi)
        {
            this.Remove(bi);
            int index = Indexes[bi];
            Indexes.Remove(bi);
            byte[] bitmapData = ((MemoryStream)bi.StreamSource).ToArray();
            Database.SQLCE.Query.RemoveImage(Word, index);
        }

        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty)
                return;
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                reader.ReadStartElement("BitmapImage");
                MemoryStream ms = null;
                byte[] buffer = new byte[256];
                int bytesRead;
                while ((bytesRead = reader.ReadContentAsBase64(
                    buffer, 0, buffer.Length)) > 0)
                {
                    if (ms == null) ms = new MemoryStream(bytesRead);
                    ms.Write(buffer, 0, bytesRead);
                }
                this.Add(ImageFromBuffer(ms.ToArray()));
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            foreach (System.Windows.Media.Imaging.BitmapImage key in this.Items)
            {
                byte[] bitmapData = ((MemoryStream)key.StreamSource).ToArray();
                writer.WriteStartElement("BitmapImage");
                writer.WriteBase64(bitmapData, 0, bitmapData.Length);
                writer.WriteEndElement();
            }
        }

        public System.Windows.Media.Imaging.BitmapImage ImageFromBuffer(Byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            System.Windows.Media.Imaging.BitmapImage image = new System.Windows.Media.Imaging.BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }

        public Byte[] BufferFromImage(System.Windows.Media.Imaging.BitmapImage imageSource)
        {
            Stream stream = imageSource.StreamSource;
            Byte[] buffer = null;
            if (stream != null && stream.Length > 0)
            {
                using (BinaryReader br = new BinaryReader(stream))
                {
                    buffer = br.ReadBytes((Int32)stream.Length);
                }
            }

            return buffer;
        }

        #endregion*/
    }
}
