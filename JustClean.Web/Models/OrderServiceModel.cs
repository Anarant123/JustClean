using JustClean.Web.Models.db;
using System.ComponentModel.DataAnnotations;

namespace JustClean.Web.Models
{
    public class OrderServiceModel
    {
        [Required(ErrorMessage = "Укажите улицу")]
        public string? Street { get; set; }

        [Required(ErrorMessage = "Укажите номер дома")]
        public int? House { get; set; }

        [Required(ErrorMessage = "Укажите номер квартиры")]
        public int? Flat { get; set; }

        [Required(ErrorMessage = "Укажите дату предоставления услуги")]
        public DateTime? ProvisionDate { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Идентификатор клиента обязателен")]
        public int IdClient { get; set; }

        [Required(ErrorMessage = "Идентификатор услуги обязателен")]
        public int? IdService { get; set; }

    }
}
