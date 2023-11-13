using System;
using System.Collections.Generic;

namespace JustClean.Web.Models.db;

public partial class Sale
{
    public int Id { get; set; }

    public int? Quantity { get; set; }

    public int? Price { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }

    public int? IdGood { get; set; }

    public int? IdUser { get; set; }

    public int? IdOffice { get; set; }

    public virtual Good? IdGoodNavigation { get; set; }

    public virtual Office? IdOfficeNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
