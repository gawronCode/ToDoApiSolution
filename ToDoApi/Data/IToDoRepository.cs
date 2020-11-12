using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Dtos;
using ToDoApi.Models;

namespace ToDoApi.Data
{
    public interface IToDoRepository
    {
        public bool SaveChanges();
        public void AddNewPerson(Person person);
        public Person GetPersonById(int id);
        public Person GetPersonByName(string personName);
        public State GetStateByName(string personName);
        public IEnumerable<PlannedTaskRead> GetPersonsPlannedTasks(string personName);
        public IEnumerable<PlannedTaskRead> GetPersonsPlannedTasksByGivenState(string personName, string stateNameCode);
        public void CreatePersonalTask(PlannedTask plannedTask);
        public void UpdatePersonalTask(string personNick, PlannedTask plannedTask);
        public void DeletePersonalTask(string personNick, PlannedTask plannedTask);

    }
}
