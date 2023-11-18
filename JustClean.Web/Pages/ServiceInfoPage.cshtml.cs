using JustClean.Web.Models.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustClean.Web.Pages
{
    public class ServiceInfoPageModel : PageModel
    {
        public JustClean.Web.Models.db.Service ServiceInfo { get; set; }
        public void OnGet()
        {
        }
    }
}
