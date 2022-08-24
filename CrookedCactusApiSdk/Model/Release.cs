using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrookedCactusApiSdk.Model
{
    public class Release
    {
        public List<string>? Arguments { get; set; }
        public string? Version { get; set; }
        public DownloadMetadata? Download { get; set; }
        public string? Type { get; set; }
        public DateTime ReleaseTimestamp { get; set; }
    }
}
