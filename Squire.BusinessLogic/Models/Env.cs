using System;
using System.Collections.Generic;
using System.Text;

namespace Squire.BusinessLogic.Models
{
    public class Env
    {
        public string Name { get; set; }

        public IList<ReleaseNote> ReleaseNotes { get; set; } = new List<ReleaseNote>();
    }
}
