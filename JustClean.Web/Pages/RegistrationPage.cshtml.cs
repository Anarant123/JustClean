using JustClean.Web.Models;
using JustClean.Web.Models.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustClean.Web.Pages
{
    public class RegistrationPageModel : PageModel
    {
        public RegModel RegModel { get; set; }
        public void OnGet()
        {
        }
    }
}
