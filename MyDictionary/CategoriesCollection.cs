using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MyDictionary
{
    public class CategoriesCollection : ObservableSortedList.SortedObservableCollection<string>, System.Xml.Serialization.IXmlSerializable
    {
        public Database.ConnectionType ConnectionType { get; private set; }

        public CategoriesCollection(Database.ConnectionType ConnectionType): base()
        {
            this.ConnectionType = ConnectionType;
        }

        public void Add(string Category,bool nadd=true)
        {
            base.Add(Category);
            if (nadd)
            {
                if(ConnectionType== Database.ConnectionType.LocalDB) Database.LocalDB.Query.AddCat(Category);
                else Database.SQLCE.Query.AddCat(Category);
            }
        }

        public void Remove(string Category)
        {
            base.Remove(Category);
            if (ConnectionType == Database.ConnectionType.LocalDB) Database.LocalDB.Query.RemoveCat(Category);
            else Database.LocalDB.Query.RemoveCat(Category);
        }

        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(string));
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty)
                return;
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                
                string key = (string)keySerializer.Deserialize(reader);
                base.Add(key);
            }
            reader.ReadEndElement();

        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(string));
            foreach (string key in this)
            {
                keySerializer.Serialize(writer, key);
            }
        }
        #endregion
    }
}
