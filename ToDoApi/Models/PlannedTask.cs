using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Models
{
    public class PlannedTask
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(2137)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public int StateId { get; set; }

        public State State { get; set; }

        [Required]
        public int PersonId { get; set; }

        public Person Person { get; set; }

    }
}
