﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Entity
{
    public record EntityPeople
    (
        int idPeople,
        string name,
        string lastName,
        int age
    )
    {
    }
}
