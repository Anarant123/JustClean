using JustClean.Web.Models;
using JustClean.Web.Models.db;
using JustClean.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustClean.Web.Pages
{
    public class RegistrationPageModel : PageModel
    {
        private readonly Repository.Repository _repository;

        [BindProperty]
        public RegModel RegModel { get; set; }
        public List<Office> Offices { get; set; }

        public string Error { get; set; }

        public RegistrationPageModel(Repository.Repository repository)
        {
            _repository = repository;
        }
        public async Task OnGet()
        {
            Offices = await _repository.GetOffices();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Offices = await _repository.GetOffices();
                return Page();
            }

            var client = await _repository.Registration(RegModel);

            if (client != null)
            {
                return RedirectToPage("/AuthorizationPage");
            }

            Offices = await _repository.GetOffices();
            Error = "Регистрация не удалась, возможно пользователь с таким логином уже зарегистрирован.";

            return Page();
        }

    }
}
