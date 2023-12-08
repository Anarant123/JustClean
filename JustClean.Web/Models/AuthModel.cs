using System.ComponentModel.DataAnnotations;

namespace JustClean.Web.Models
{
    public class AuthModel
    {
        [Required(ErrorMessage = "Пожалуйста, введите логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        public string Password { get; set; }
    }
}
