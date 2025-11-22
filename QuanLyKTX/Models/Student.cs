using System;
using System.Collections.Generic;

namespace QuanLyKTX.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentCode { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string Idcard { get; set; } = null!;

    public string? Address { get; set; }

    public string? Faculty { get; set; }

    public string? Major { get; set; }

    public string? Class { get; set; }

    public string? Status { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual User? User { get; set; }
}
