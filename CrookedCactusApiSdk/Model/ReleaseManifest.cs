using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrookedCactusApiSdk.Model
{
    public class ReleaseManifest
    {
        public Latest? Latest { get; set; }
        public List<ReleaseMetadata>? Releases { get; set; }
    }

    public class Latest {
        public string? Release { get; set; }
    }
}
