using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    public class FinishCommand : AbstractCommand
    {
        public override void runCommand(string nBundleXml)
        {
            Bundle bundle_ = Deserialize<Bundle>(nBundleXml);
            string finishBundleXml_ = bundle_.mDirectorys[mDirectory];
            FinishBundle finishBundle = Deserialize<FinishBundle>(finishBundleXml_);
            finishBundle.runCommand(bundle_);
        }

        public string mDirectory { get; set; }
    }
}
