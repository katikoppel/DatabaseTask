using System;
using System.Collections.Generic;

namespace DatabaseTask.Models;

public partial class Child
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public virtual Employee? Employee { get; set; }
}
