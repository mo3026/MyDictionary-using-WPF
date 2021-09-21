using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MyDictionary
{
    class Dictionary
    {
        public static void save(CategoriesCollection c,DefinitionCollection d)
        {
            System.Xml.Serialization.XmlSerializer serializer2 = new System.Xml.Serialization.XmlSerializer(typeof(CategoriesCollection));
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(DefinitionCollection));
            System.Xml.XmlWriter w = System.Xml.XmlWriter.Create(@"dictionarySerialized.xml");
            w.WriteStartElement("Dictionary");
            serializer2.Serialize(w, c);
            serializer.Serialize(w, d);
            w.WriteEndElement();
            w.Close();
        }

        public static void read(out CategoriesCollection c, out DefinitionCollection d,string path)
        {
            System.Xml.Serialization.XmlSerializer serializer2 = new System.Xml.Serialization.XmlSerializer(typeof(CategoriesCollection));
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(DefinitionCollection));
            System.Xml.XmlReader r = System.Xml.XmlReader.Create(path);
            r.ReadStartElement("Dictionary");
            c = (CategoriesCollection)serializer2.Deserialize(r);
            d = (DefinitionCollection)serializer.Deserialize(r);
            r.Read();
            r.Close();
        }
    }
}
