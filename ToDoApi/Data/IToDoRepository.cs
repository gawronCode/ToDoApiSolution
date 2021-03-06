﻿using System;
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
        public void UpdateTask(PlannedTaskUpdate plannedTaskUpdate, PlannedTask plannedTask);
        public void DeleteTask(PlannedTask plannedTask);
        public PlannedTask GetPlannedTaskById(int id);

    }
}
