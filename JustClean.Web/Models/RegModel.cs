using System.ComponentModel.DataAnnotations;

namespace JustClean.Web.Models
{

    public class RegModel
    {
        [Required(ErrorMessage = "Фамилия обязательна")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Имя обязательно")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Отчество обязательно")]
        public string? Patronymic { get; set; }

        [Required(ErrorMessage = "Номер телефона обязателен")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Электронная почта обязательна")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты")]
        public string? Mail { get; set; }

        [Display(Name = "Компания")]
        public bool? Company { get; set; }

        [Required(ErrorMessage = "Описание обязательно")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Идентификатор пользователя обязателен")]
        public int? IdUser { get; set; }

        [Required(ErrorMessage = "Офис должен быть обязательно выбран")]
        public int? IdOffice { get; set; }

        [Required(ErrorMessage = "Логин обязателен")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Повтор пароля обязателен")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
