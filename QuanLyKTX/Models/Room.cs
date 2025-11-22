using System;
using System.Collections.Generic;

namespace QuanLyKTX.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public string Building { get; set; } = null!;

    public int Floor { get; set; }

    public string RoomType { get; set; } = null!;

    public int Capacity { get; set; }

    public int? CurrentOccupancy { get; set; }

    public decimal PricePerMonth { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
