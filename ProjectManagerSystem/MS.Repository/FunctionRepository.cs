﻿using MS.DataAccess;
using MS.DataAccess.Models;
using MS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Repository
{
    public class FunctionRepository : BaseRepository<Function>, IFunctionRepository
    {
        public FunctionRepository(MsContext context) : base(context)
        {

        }
    }
}
