using System;
using System.Collections.Generic;
using System.Text;

namespace Squire.BusinessLogic.Models
{
    public class ReleaseNote
    {
        public string VersionNumber { get; set; }

        public string Summary { get; set; }

        public IList<Feature> Features { get; set; } = new List<Feature>();

        public IList<Bugfix> Bugfixes { get; set; } = new List<Bugfix>();
    }
}
