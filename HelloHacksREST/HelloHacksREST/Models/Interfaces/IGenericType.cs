﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHacksREST.Models.Interfaces
{
    interface IGenericType
    {
        int Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }
    }
}
