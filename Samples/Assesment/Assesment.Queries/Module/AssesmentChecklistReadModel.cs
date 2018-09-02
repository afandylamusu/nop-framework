using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Queries.Module
{
    public class AssesmentChecklistReadModel : SqlReadModel
    {
        public string Name { get; set; }
        public string ModuleId { get; set; }
    }
}
