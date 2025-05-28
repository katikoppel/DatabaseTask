using System;
using System.Collections.Generic;

namespace DatabaseTask.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? PersonalCode { get; set; }

    public int? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<Child> Children { get; set; } = new List<Child>();

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();
}
