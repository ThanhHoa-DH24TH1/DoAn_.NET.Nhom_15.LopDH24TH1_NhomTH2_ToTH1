using System;
using System.Collections.Generic;

namespace QuanLyKTX.Models;

public partial class Contract
{
    public int ContractId { get; set; }

    public int StudentId { get; set; }

    public int RoomId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal MonthlyFee { get; set; }

    public decimal Deposit { get; set; }

    public string? Status { get; set; }

    public DateOnly? SignedDate { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Room Room { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
