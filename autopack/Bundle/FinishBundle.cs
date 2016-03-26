using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    class FinishBundle : SerailizeXml
    {
        public void runCommand(Bundle nBundle)
        {
            string versionNoXml_ = nBundle.mDirectorys["versionNo"];
            VersionNo versionNo_ = Deserialize<VersionNo>(versionNoXml_);

            foreach (CopyOnce i in mCopyOnces)
            {
                i.runCopy(nBundle);
            }
            foreach (DeleteOnce i in mDeleteOnces)
            {
                i.runDelete(nBundle);
            }
            foreach (ZipOnce i in mZipOnces)
            {
                i.runZip(nBundle);
            }

            Console.WriteLine("APK:{0} UPDATE:{1}", versionNo_.mApkNo, versionNo_.mUpdateNo);
            Console.ReadKey(true);
        }

        public List<CopyOnce> mCopyOnces { get; set; }

        public List<DeleteOnce> mDeleteOnces { get; set; }

        public List<ZipOnce> mZipOnces { get; set; }
    }
}
