using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    public class ZipCommand : AbstractCommand
    {
        public List<ZipIfOnce> mZipIfOnces { get; set; }

        public override void runCommand(string nBundleXml)
        {
            Bundle bundle_ = Deserialize<Bundle>(nBundleXml);
            foreach (ZipIfOnce i in mZipIfOnces)
            {
                i.runZip(bundle_);
            }
        }
    }
}
