using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace MyDictionary
{
    public class DefinitionCollection : SortedDictionary<string, Definition>, System.Collections.Specialized.INotifyCollectionChanged, System.Xml.Serialization.IXmlSerializable
    {
        public Database.ConnectionType ConnectionType{ get; private set; }

        public DefinitionCollection(Database.ConnectionType ConnectionType)
            : base()
        {
            this.ConnectionType = ConnectionType;
        }

        public event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChanged;

        private void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs propertyName)
        {
            if (CollectionChanged != null) CollectionChanged(this, propertyName);
        }

        public void Add(string Word,Definition Definition,bool Add)
        {
            base.Add(Word, Definition);
            OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));

            if (Add)
            {
                StringBuilder s = new StringBuilder();
                System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                System.Xml.XmlWriter x = System.Xml.XmlWriter.Create(s, settings);
                x.WriteStartElement("Definition");
                Definition.WriteXml(x);
                x.WriteEndElement();
                x.Flush();
                if (ConnectionType == Database.ConnectionType.LocalDB) Database.LocalDB.Query.AddDefinition(Word, s.ToString());
                else Database.SQLCE.Query.AddDefinition(Word, s.ToString());

                foreach (System.Windows.Media.Imaging.BitmapImage key in Definition.Images)
                {
                    byte[] bitmapData = ((MemoryStream)key.StreamSource).ToArray();
                    if (ConnectionType == Database.ConnectionType.LocalDB) Database.LocalDB.Query.AddImage(Word, bitmapData);
                    else Database.SQLCE.Query.AddImage(Word, bitmapData);
                }
            }
        }

        public void Remove(string Word)
        {
            base.Remove(Word);
            OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
            if (ConnectionType == Database.ConnectionType.LocalDB) Database.LocalDB.Query.RemoveDefinition(Word);
            else Database.SQLCE.Query.RemoveDefinition(Word);
        }


        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            
            XmlSerializer keySerializer = new XmlSerializer(typeof(string));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(Definition));
            bool wasEmpty = reader.IsEmptyElement;
            reader.ReadStartElement("DefinitionCollection");
            if (wasEmpty)
                return;
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {               
                reader.ReadStartElement("item");
                reader.ReadStartElement("key");
                string key = (string)keySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("value");
                Definition value = (Definition)valueSerializer.Deserialize(reader);
                reader.ReadEndElement();
                this.Add(key, value);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();

        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(string));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(Definition));
            foreach (string key in this.Keys)
            {
                writer.WriteStartElement("item");
                writer.WriteStartElement("key");
                keySerializer.Serialize(writer, key);
                writer.WriteEndElement();
                writer.WriteStartElement("value");
                Definition value = this[key];
                valueSerializer.Serialize(writer, value);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
        #endregion
    }
}
