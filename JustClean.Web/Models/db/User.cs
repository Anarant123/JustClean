using System;
using System.Collections.Generic;

namespace JustClean.Web.Models.db;

public partial class User
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public string? Phone { get; set; }

    public string? Mail { get; set; }

    public byte[]? Image { get; set; }

    public string? Description { get; set; }

    public bool? Ban { get; set; }

    public int? InvitationCode { get; set; }

    public int? IdUserRole { get; set; }

    public int? IdOffice { get; set; }

    public virtual ICollection<Audit> Audits { get; set; } = new List<Audit>();

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();

    public virtual Office? IdOfficeNavigation { get; set; }

    public virtual Userrole? IdUserRoleNavigation { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
