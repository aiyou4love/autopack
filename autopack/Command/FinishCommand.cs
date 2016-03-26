using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    class FinishCommand : AbstractCommand
    {
        public override void runCommand(string nBundleXml)
        {
            Bundle bundle_ = Deserialize<Bundle>(nBundleXml);
            string finishBundleXml_ = bundle_.mDirectorys["finishBundle"];
            FinishBundle finishBundle = Deserialize<FinishBundle>(finishBundleXml_);
            finishBundle.runCommand(bundle_);
        }
    }
}
