﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Dtos
{
    public class PlannedTaskUpdate
    {
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string State { get; set; }

    }
}
