using System;
using System.Collections.Generic;

namespace JustClean.Web.Models.db;

public partial class Good
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? PurchasePrice { get; set; }

    public int? SalePrice { get; set; }

    public byte[]? Image { get; set; }

    public string? Description { get; set; }

    public int? IdProvider { get; set; }

    public int? IdOffice { get; set; }

    public virtual Office? IdOfficeNavigation { get; set; }

    public virtual Provider? IdProviderNavigation { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
