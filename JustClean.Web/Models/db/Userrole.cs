using System;
using System.Collections.Generic;

namespace JustClean.Web.Models.db;

public partial class Userrole
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
