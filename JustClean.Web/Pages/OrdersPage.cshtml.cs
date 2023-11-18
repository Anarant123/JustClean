using JustClean.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustClean.Web.Pages
{
    public class OrdersPageModel : PageModel
    {
        private readonly CookieService _cookieService;
        public OrdersPageModel(CookieService cookieService) 
        {
            _cookieService = cookieService;
        }
        public IActionResult OnGet()
        {
            var id = _cookieService.GetCookie("ClientData");

            if (id == -1)
                return RedirectToPage("/AuthorizationPage", new { id = id });

            return Page();
        }
    }
}
