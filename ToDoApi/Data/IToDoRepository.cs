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
        public Person GetPersonById(int id);
        public IEnumerable<PlannedTask> GetPersonsPlannedTasks(string person);
        public IEnumerable<PlannedTask> GetPersonsPlannedTasksByGivenState(string person, string state);
        public void CreatePersonalTask(string personNick, PlannedTask plannedTask);
        public void UpdatePersonalTask(string personNick, PlannedTask plannedTask);
        public void DeletePersonalTask(string personNick, PlannedTask plannedTask);

    }
}
