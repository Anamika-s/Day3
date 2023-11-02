using System;
using System.Collections.Generic;

namespace EFramework.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public int? Salary { get; set; }
}
