using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace autopack
{
    [Serializable]
    public class UpdateCommand : AbstractCommand
    {
        public override void runCommand(string nBundleXml)
        {
            Bundle bundle_ = Deserialize<Bundle>(nBundleXml);
            string buildBundleXml_ = bundle_.mDirectorys["buildBundle"];
            BuildBundle buildBundle_ = Deserialize<BuildBundle>(buildBundleXml_);
            buildBundle_.runCommand(mCommand, bundle_);
        }

        public string mCommand { get; set; }
    }
}
