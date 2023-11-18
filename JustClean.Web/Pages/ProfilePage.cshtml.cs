using JustClean.Web.Models;
using JustClean.Web.Models.db;
using JustClean.Web.Repository;
using JustClean.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustClean.Web.Pages
{
    public class ProfilePageModel : PageModel
    {
        private readonly Repository.Repository _repository;
        private readonly CookieService _cookieService;
        public Client Client { get; set; }

        public ProfilePageModel(Repository.Repository repository, CookieService cookieService)
        {
            _repository = repository;
            _cookieService = cookieService;
        }
        public async Task OnGetAsync(int id)
        {
            Client = await _repository.GetClient(id);
        }

        public IActionResult OnPost()
        {
            _cookieService.DeleteCookie("ClientData");
            return RedirectToPage("/AuthorizationPage");
        }
    }
}
