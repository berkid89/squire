using System;
using System.Collections.Generic;
using System.Text;

namespace Squire.BusinessLogic.Models
{
    public class Software : BusinessEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<Env> Envs { get; set; } = new List<Env>();
    }
}
