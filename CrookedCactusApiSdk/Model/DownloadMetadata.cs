using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrookedCactusApiSdk.Model
{
    public class DownloadMetadata
    {
        public string? Url { get; set; }
        public int Size { get; set; }
        public string? Sha { get; set; }
    }
}
