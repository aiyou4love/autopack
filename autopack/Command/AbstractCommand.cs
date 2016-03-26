using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace autopack
{
    [Serializable]
    public abstract class AbstractCommand : SerailizeXml
    {
        public abstract void runCommand(string nBundleXml);

        public string getName()
        {
            return mName;
        }

        public string mName { get; set; }
    }
}
