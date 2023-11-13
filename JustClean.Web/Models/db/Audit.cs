using System;
using System.Collections.Generic;

namespace JustClean.Web.Models.db;

public partial class Audit
{
    public int Id { get; set; }

    public DateTime? Time { get; set; }

    public string? Event { get; set; }

    public int? IdUser { get; set; }

    public int? IdOffice { get; set; }

    public virtual Office? IdOfficeNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
