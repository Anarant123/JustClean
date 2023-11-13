using System;
using System.Collections.Generic;

namespace JustClean.Web.Models.db;

public partial class Dealstatus
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();
}
