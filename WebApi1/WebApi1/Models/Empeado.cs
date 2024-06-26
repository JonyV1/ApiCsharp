using System;
using System.Collections.Generic;

namespace WebApi1.Models;

public partial class Empeado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public int? Sueldo { get; set; }
}
