﻿using MS.DataAccess.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service.Interface
{
    public interface ITasksService
    {
        Tasks AddTasks(Tasks item);
        Tasks DeleteTasks(Tasks item);
        bool UpdateTasks(Tasks item);
        Tasks GetTasks(int ID);
        Tasks GetTasks(string ID);
        IEnumerable<Tasks> GetAll();
        void SaveChange();
        Tasks DeleteTasksbyId(int ID);
    }
}
