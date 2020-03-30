﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.API.Data.Models.Dominio
{
#nullable enable
    public class DominioShowDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public DominioShowDTO? Padre { get; set; }
    }
}