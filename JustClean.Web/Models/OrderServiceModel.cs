using JustClean.Web.Models.db;

namespace JustClean.Web.Models
{
    public class OrderServiceModel
    {
        public string? Street { get; set; }

        public int? House { get; set; }

        public int? Flat { get; set; }

        public DateTime? ProvisionDate { get; set; }

        public string? Description { get; set; }

        public int IdClient { get; set; }

        public int? IdService { get; set; }

    }
}
