using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    class BuildPackage : SerailizeXml
    {
        public void runCommand(Bundle nBundle)
        {
            mClearDirectory.runClear(nBundle);

            foreach (CopyOnce i in mCopyOnces)
            {
                i.runCopy(nBundle);
            }
        }

        ClearDirectory mClearDirectory { get; set; }

        public List<CopyOnce> mCopyOnces { get; set; }
    }
}
