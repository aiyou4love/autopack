using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    public class PrintCommand : AbstractCommand
    {
        public override void runCommand(string nBundleXml)
        {
            Bundle bundle_ = Deserialize<Bundle>(nBundleXml);
            string versionNoXml_ = bundle_.mDirectorys["versionNo"];
            VersionNo versionNo_ = Deserialize<VersionNo>(versionNoXml_);

            Console.WriteLine("APK:{0} UPDATE:{1}", versionNo_.mApkNo, versionNo_.mUpdateNo);
            Console.ReadKey(true);
        }
    }
}
