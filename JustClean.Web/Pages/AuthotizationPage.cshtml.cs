using JustClean.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustClean.Web.Pages
{
    public class AuthotizationPageModel : PageModel
    {
        public AuthModel AuthModel { get; set; }
        public void OnGet()
        {
        }
    }
}
