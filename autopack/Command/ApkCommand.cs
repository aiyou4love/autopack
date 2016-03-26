using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    public class ApkCommand : AbstractCommand
    {
        public override void runCommand(string nBundleXml)
        {
            Bundle bundle_ = Deserialize<Bundle>(nBundleXml);
            string initBundleXml_ = bundle_.mDirectorys["initBundle"];
            InitBundle initBundle_ = Deserialize<InitBundle>(initBundleXml_);
            initBundle_.runCommand(mCommand, bundle_);
        }

        public string mCommand { get; set; }
    }
}
