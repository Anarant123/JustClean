using System;
using System.Collections.Generic;

namespace JustClean.Web.Models.db;

public partial class Provider
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Mail { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
}
