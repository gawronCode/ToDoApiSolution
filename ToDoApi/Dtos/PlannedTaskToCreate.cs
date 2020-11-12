using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Dtos
{
    public class PlannedTaskToCreate
    {
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string State { get; set; }

        public string Person { get; set; }
    }
}
