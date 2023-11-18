using JustClean.Web.Models.db;
using JustClean.Web.Repository;
using JustClean.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustClean.Web.Pages
{
    public class ServicesPageModel : PageModel
    {
        public List<JustClean.Web.Models.db.Service> Services { get; set; }
        private readonly Repository.Repository _repository;
        private readonly CookieService _cookieService;

        public ServicesPageModel(Repository.Repository repository, CookieService cookieService)
        {
            _repository = repository;
            _cookieService = cookieService;
        }
        public async Task OnGet()
        {
            Services = await _repository.GetService();
        }

        public async Task<IActionResult> OnPostAsync(int serviceId)
        {
            return RedirectToPage("/ServiceInfoPage", new { id = serviceId });
        }
    }
}
