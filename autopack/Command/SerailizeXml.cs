using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace autopack
{
    public class SerailizeXml
    {
        protected void Serialize<T>(string nFileName, T nT)
        {
            using (FileStream fileStream_ = new FileStream(nFileName, FileMode.Create))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlSerializer xmlSerializer_ = new XmlSerializer(typeof(T));
                xmlSerializer_.Serialize(fileStream_, nT, ns);
                fileStream_.Close();
            }
        }

        protected T Deserialize<T>(string nFileName)
        {
            T result_;
            using (FileStream fileStream_ = new FileStream(nFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                XmlSerializer xmlSerializer_ = new XmlSerializer(typeof(T));
                result_ = (T)xmlSerializer_.Deserialize(fileStream_);
                fileStream_.Close();
            }
            return result_;
        }
    }
}
