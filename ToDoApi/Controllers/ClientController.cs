using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Data;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{

    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IToDoRepository _repository;

        public ClientController(IToDoRepository repository)
        {
            _repository = repository;
        }

        public ActionResult<Person> AddNewPerson(string personNick)
        {
            return new Person();
        }

        public ActionResult<IEnumerable<PlannedTask>> GetPersonsPlannedTasks(string personNick)
        {
            return new LinkedList<PlannedTask>();
        }

        public ActionResult<IEnumerable<PlannedTask>> GetPersonsPlannedTasksByGivenState(string personNick, string state)
        {
            return new LinkedList<PlannedTask>();
        }

        public ActionResult<PlannedTask> CreatePersonalTask(string personNick, PlannedTask plannedTask)
        {
            return new PlannedTask();
        }

        public void UpdatePersonalTask(string personNick, PlannedTask plannedTask)
        {

        }

        public void DeletePersonalTask(string person, PlannedTask plannedTask)
        {

        }



    }
}
