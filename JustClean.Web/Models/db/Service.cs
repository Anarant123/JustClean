using System;
using System.Collections.Generic;

namespace JustClean.Web.Models.db;

public partial class Service
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }

    public byte[]? Image { get; set; }

    public string? Description { get; set; }

    public int? OfficeId { get; set; }

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();

    public virtual Office? Office { get; set; }
}
