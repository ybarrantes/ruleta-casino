﻿using System;

namespace Casino.API.Data.Entities.Extension
{
    /// <summary>
    /// Agrega la capacidad de 'borrado suave' de una entidad
    /// </summary>
    interface ISoftDeletes
    {
        public DateTime DeletedAt { get; set; }
    }
}