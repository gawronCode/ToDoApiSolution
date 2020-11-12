using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Data;
using ToDoApi.Dtos;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly IToDoRepository _repository;

        public ToDoController(IToDoRepository repository)
        {
            _repository = repository;
        }
        
        [HttpPost("AddNewPerson")]
        public ActionResult<Person> AddNewPerson(Person person)
        {
            _repository.AddNewPerson(person);
            _repository.SaveChanges();
            return CreatedAtRoute(GetPersonById(person.Id), person);
        }

        private ActionResult<Person> GetPersonById(int id)
        {
            var person = _repository.GetPersonById(id);
            if (person is null) return NotFound();
            return person;
        }

        [HttpGet("GetTasks/{personNick}")]
        public ActionResult<IEnumerable<PlannedTask>> GetPersonsPlannedTasks(string personNick)
        {
            return new LinkedList<PlannedTask>();
        }

        [HttpGet("GetTasks/{personNick}/{state}")]
        public ActionResult<IEnumerable<PlannedTask>> GetPersonsPlannedTasksByGivenState(string personNick, string state)
        {
            return new LinkedList<PlannedTask>();
        }

        [HttpPost("CreateTask")]
        public ActionResult CreatePersonalTask(PlannedTaskToCreate plannedTask)
        {
            var person = _repository.GetPersonByName(plannedTask.Person);
            if (person is null) return NotFound();
            var state = _repository.GetStateByName(plannedTask.State);
            if (state is null) return NotFound();

            var newTask = new PlannedTask()
            {
                Description = plannedTask.Description,
                DueDate = plannedTask.DueDate,
                PersonId = person.Id,
                StateId = state.Id
            };

            _repository.CreatePersonalTask(newTask);
            _repository.SaveChanges();
            return Ok();

        }

        [NonAction]
        public void UpdatePersonalTask(string personNick, PlannedTask plannedTask)
        {

        }
        [NonAction]
        public void DeletePersonalTask(string person, PlannedTask plannedTask)
        {

        }



    }
}
