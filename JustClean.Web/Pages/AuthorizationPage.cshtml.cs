using JustClean.Web.Models;
using JustClean.Web.Models.db;
using JustClean.Web.Repository;
using JustClean.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace JustClean.Web.Pages
{
    public class AuthorizationPageModel : PageModel
    {
        private readonly Repository.Repository _repository;
        private readonly CookieService _cookieService;
        public AuthModel AuthModel { get; set; }

        public AuthorizationPageModel(Repository.Repository repository, CookieService cookieService)
        {
            _repository = repository;
            _cookieService = cookieService;
        }

        public IActionResult OnGet()
        {
            var id = _cookieService.GetCookie("ClientData");
            
            if(id != -1)
                return RedirectToPage("/ProfilePage", new { id = id });

            return Page();

        }

        public async Task<IActionResult> OnPostAsync(AuthModel authModel)
        {
            var client = await _repository.Authorization(authModel);
            if (client != null)
            {
                _cookieService.SetCookie("ClientData", client.Id);
                return RedirectToPage("/ProfilePage", new { id = client.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ошибка: Неверный логин или пароль");
                return Page();
            }
        }
    }
}
