using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace autopack
{
    [Serializable]
    [XmlRoot("Dictionary")]
    public class SerializableDictionary<KT, VT>:Dictionary<KT ,VT>,IXmlSerializable
    {
        public SerializableDictionary(SerializationInfo info, StreamingContext context):base(info,context)
        {

        }
        public SerializableDictionary()
        {

        }
        public XmlSchema GetSchema()
        {
            return (null);
        }
        public void ReadXml(XmlReader reader)
        {
            Boolean wasEmpty = reader.IsEmptyElement;

            reader.Read();

            if (wasEmpty)
            {
                return;
            }

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                KT key ;
                
                reader.Read();
                
                reader.Read();
                key = (KT)new XmlSerializer(typeof(KT)).Deserialize(reader);
                reader.ReadEndElement();
                
                reader.Read();
                Add(key, (VT)new XmlSerializer(typeof(VT)).Deserialize(reader));
                reader.ReadEndElement();
                
                reader.ReadEndElement();
                
                reader.MoveToContent();
            }

            reader.ReadEndElement();

        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            for (int i=0;i<Keys.Count;i++)
            {
                KT key =Keys.ElementAt(i);
                VT value= this.ElementAt(i).Value;
                //create <item>
                writer.WriteStartElement("Item");
                //create <key> under <item>
                writer.WriteStartElement("Key");
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                new XmlSerializer(key.GetType()).Serialize(writer, key, ns);
                //end </key> element               
                writer.WriteEndElement();
                //create <value> under <item>
                writer.WriteStartElement("value");
                
                new XmlSerializer(value.GetType()).Serialize(writer, value, ns);

                //end </value>  
                writer.WriteEndElement();
                //end </item>
                writer.WriteEndElement();
            }
        }      
       
    }
}
