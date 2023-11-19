using JustClean.Web.Models.db;
using JustClean.Web.Repository;
using JustClean.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustClean.Web.Pages
{
    public class OrdersPageModel : PageModel
    {
        private readonly CookieService _cookieService;
        private readonly Repository.Repository _repository;

        public List<Deal> Deals { get; set; }

        public OrdersPageModel(Repository.Repository repository, CookieService cookieService) 
        {
            _cookieService = cookieService;
            _repository = repository;
        }
        public async Task<IActionResult> OnGet()
        {
            var id = _cookieService.GetCookie("ClientData");

            if (id == -1)
                return RedirectToPage("/AuthorizationPage", new { id = id });

            Deals = await _repository.GetDeals(id);
            return Page();
        }
    }
}
