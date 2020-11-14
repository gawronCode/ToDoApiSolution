using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ToDoApi.Dtos;
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

        public Person GetPersonByName(string personName)
        {
            return _context.Person.FirstOrDefault(p => p.Name == personName);
        }

        public State GetStateByName(string personName)
        {
            return _context.State.FirstOrDefault(p => p.Name == personName);
        }

        public void CreatePersonalTask(PlannedTask plannedTask)
        {
            if(plannedTask is null) throw new ArgumentException(nameof(plannedTask));
            _context.PlannedTask.Add(plannedTask);
        }

        public void DeleteTask(PlannedTask plannedTask)
        {
            if(plannedTask is null) throw new ArgumentException(nameof(plannedTask));
            _context.PlannedTask.Remove(plannedTask);
        }

        public PlannedTask GetPlannedTaskById(int id)
        {
            return _context.PlannedTask.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<PlannedTaskRead> GetPersonsPlannedTasks(string personName)
        {
            return from p in _context.PlannedTask 
                orderby p.DueDate 
                where p.Person.Name == personName 
                select new PlannedTaskRead() 
                {
                    Id = p.Id, 
                    Description = p.Description, 
                    DueDate = p.DueDate, 
                    State = p.State.Name
                };
        }

        public IEnumerable<PlannedTaskRead> GetPersonsPlannedTasksByGivenState(string personName, string stateNameCode)
        {
            return from p in _context.PlannedTask
                orderby p.DueDate
                where p.Person.Name == personName && p.State.Name == GetStateNameByCode(stateNameCode)
                select new PlannedTaskRead()
                {
                    Id = p.Id,
                    Description = p.Description,
                    DueDate = p.DueDate,
                    State = p.State.Name
                };
        }

        private string GetStateNameByCode(string stateNameCode)
        {
            if (stateNameCode == "ToDo") return "To Do";
            if (stateNameCode == "InProgress") return "In Progress";
            if (stateNameCode == "Done") return "Done";

            return String.Empty;
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
