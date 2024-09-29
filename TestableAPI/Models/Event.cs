using System;
using System.Collections.Generic;

namespace TestableAPI.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Location { get; set; }

    public DateTime Date { get; set; }
}
