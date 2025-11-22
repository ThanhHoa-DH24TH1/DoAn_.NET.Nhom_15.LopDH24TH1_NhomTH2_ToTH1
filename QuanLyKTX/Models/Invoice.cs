using System;
using System.Collections.Generic;

namespace QuanLyKTX.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int ContractId { get; set; }

    public int StudentId { get; set; }

    public string BillingMonth { get; set; } = null!;

    public decimal RoomFee { get; set; }

    public decimal? ElectricityFee { get; set; }

    public decimal? WaterFee { get; set; }

    public decimal? InternetFee { get; set; }

    public decimal? ServiceFee { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? PaidAmount { get; set; }

    public decimal RemainingAmount { get; set; }

    public string? Status { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? BillingYear { get; set; }

    public virtual Contract Contract { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Student Student { get; set; } = null!;
}
