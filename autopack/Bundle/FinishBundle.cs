using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    public class FinishBundle : SerailizeXml
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
        }

        public List<CopyOnce> mCopyOnces { get; set; }

        public List<DeleteOnce> mDeleteOnces { get; set; }

        public List<ZipOnce> mZipOnces { get; set; }
    }
}
