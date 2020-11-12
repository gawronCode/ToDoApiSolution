using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Data
{
    public class SqlToDoRepository : IToDoRepository
    {

        private readonly ToDoApiContext _context;

        public SqlToDoRepository(ToDoApiContext context)
        {
            _context = context;
        }

        public void AddNewPerson(Person person)
        {
            if(person is null) throw new ArgumentNullException(nameof(person));
            _context.Person.Add(person);
        }

        public Person GetPersonById(int id)
        {
            return _context.Person.FirstOrDefault(p => p.Id == id);
        }

        public Person GetPersonByName(string name)
        {
            return _context.Person.FirstOrDefault(p => p.Name == name);
        }

        public State GetStateByName(string name)
        {
            return _context.State.FirstOrDefault(p => p.Name == name);
        }

        public void CreatePersonalTask(PlannedTask plannedTask)
        {
            if(plannedTask is null) throw new ArgumentException(nameof(plannedTask));
            _context.PlannedTask.Add(plannedTask);
        }

        public void DeletePersonalTask(string personNick, PlannedTask plannedTask)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlannedTask> GetPersonsPlannedTasks(string person)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlannedTask> GetPersonsPlannedTasksByGivenState(string person, string state)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePersonalTask(string personNick, PlannedTask plannedTask)
        {
            throw new NotImplementedException();
        }
    }
}
