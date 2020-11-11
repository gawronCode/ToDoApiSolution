using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Data
{
    public interface IToDoRepository
    {
        public bool SaveChanges();
        public void AddNewPerson(Person person);
        public IEnumerable<PlannedTask> GetPersonsPlannedTasks(Person person);
        public IEnumerable<PlannedTask> GetPersonsPlannedTasksByGivenState(Person person, string state);
        public void CreatePersonalTask(Person person, PlannedTask plannedTask);
        public void UpdatePersonalTask(Person person, PlannedTask plannedTask);
        public void DeletePersonalTask(Person person, PlannedTask plannedTask);


    }
}
