﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Queries.Module
{
    public class AssesmentAttributeReadModel : SqlReadModel
    {
        //public string ChecklistId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
