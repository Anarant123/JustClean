using System;
using System.Collections.Generic;

namespace JustClean.Web.Models.db;

public partial class Office
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Region { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? House { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Audit> Audits { get; set; } = new List<Audit>();

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
