using System;
using System.Collections.Generic;

namespace JustClean.Web.Models.db;

public partial class Deal
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Cost { get; set; }

    public string? Street { get; set; }

    public int? House { get; set; }

    public int? Flat { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ProvisionDate { get; set; }

    public string? Description { get; set; }

    public int? IdStatus { get; set; }

    public int? IdClient { get; set; }

    public int? IdOffice { get; set; }

    public int? IdUser { get; set; }

    public int? IdService { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Office? IdOfficeNavigation { get; set; }

    public virtual Service? IdServiceNavigation { get; set; }

    public virtual Dealstatus? IdStatusNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
