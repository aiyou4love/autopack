using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace autopack
{
    public abstract class AbstractCommand : SerailizeXml
    {
        public abstract void runCommand(string nBundleXml);
    }
}
