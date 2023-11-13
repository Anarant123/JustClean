using System;
using System.Collections.Generic;

namespace JustClean.Web.Models.db;

public partial class Client
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public string? Phone { get; set; }

    public string? Mail { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool? Company { get; set; }

    public string? Description { get; set; }

    public int? IdUser { get; set; }

    public int? IdOffice { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();

    public virtual Office? IdOfficeNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
