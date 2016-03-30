using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    public class BuildCommand : AbstractCommand
    {
        public override void runCommand(string nBundleXml)
        {
            Bundle bundle_ = Deserialize<Bundle>(nBundleXml);
            string buildPackageXml_ = bundle_.mDirectorys[mDirectory];
            BuildPackage buildPackage_ = Deserialize<BuildPackage>(buildPackageXml_);
            buildPackage_.runCommand(bundle_);
        }

        public string mDirectory { get; set; }
    }
}
