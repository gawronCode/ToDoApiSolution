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
        public ActionResult<IEnumerable<PlannedTaskRead>> GetPersonsPlannedTasks(string personNick)
        {
            var tasks = _repository.GetPersonsPlannedTasks(personNick);
            if (!tasks.Any()) return NotFound();
            return Ok(tasks);
        }

        [HttpGet("GetTasks/{personNick}/{stateNameCode}")]
        public ActionResult<IEnumerable<PlannedTaskRead>> GetPersonsPlannedTasksByGivenState(string personNick, string stateNameCode)
        {
            var tasks = _repository.GetPersonsPlannedTasksByGivenState(personNick, stateNameCode);
            if (!tasks.Any()) return NotFound();
            return Ok(tasks);
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

        [HttpPatch("Update/{id}")]
        public ActionResult UpdatePersonalTask(int id, PlannedTaskUpdate plannedTaskUpdate)
        {
            var plannedTaskToUpdate = _repository.GetPlannedTaskById(id);
            if (plannedTaskToUpdate is null) return NotFound();
            _repository.UpdateTask(plannedTaskUpdate, plannedTaskToUpdate);
            _repository.SaveChanges();
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteTask(int id)
        {
            var plannedTaskToDelete = _repository.GetPlannedTaskById(id);
            if (plannedTaskToDelete is null) return NotFound();
            _repository.DeleteTask(plannedTaskToDelete);
            _repository.SaveChanges();
            return Ok();
        }

    }
}
