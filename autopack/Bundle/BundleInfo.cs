using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    public class BundleInfo
    {
        public SerializableDictionary<string, Md5Info> mMd5Infos { get; set; }
    }
}
