using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrookedCactusApiSdk.Model
{
    public class ReleaseMetadata
    {
        public string? Version { get; set; }
        public string? Type { get; set; }
        public string? Url { get; set; }
        public DateTime? ReleaseTimestamp { get; set; }
    }
}
