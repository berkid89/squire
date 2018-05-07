using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Squire.BusinessLogic.Models
{
    public class Software : BusinessEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<Env> Envs { get; set; } = new List<Env>();
    }

    public class WidgetSoftware : Software
    {
        public IList<ReleaseNote> ReleaseNotes { get; set; } = new List<ReleaseNote>();

        public WidgetSoftware(Software original, string envName)
        {
            Id = original.Id;
            Name = original.Name;
            Description = original.Description;
            ReleaseNotes = original.Envs.First(p => p.Name == envName).ReleaseNotes;
            Envs = null;
        }
    }
}
