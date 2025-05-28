using System;
using System.Collections.Generic;

namespace DatabaseTask.Models;

public partial class Salary
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public decimal? SalaryAmount { get; set; }

    public DateOnly? StartDate { get; set; }

    public virtual Employee? Employee { get; set; }
}
