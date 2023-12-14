using JustClean.Web.Models;
using JustClean.Web.Models.db;
using JustClean.Web.Repository;
using JustClean.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustClean.Web.Pages
{
    public class ServiceInfoPageModel : PageModel
    {
        private readonly Repository.Repository _repository;
        private readonly CookieService _cookieService;
        public JustClean.Web.Models.db.Service ServiceInfo { get; set; }
        [BindProperty]
        public OrderServiceModel OrderServiceModel { get; set; }
        public int IdClient { get; set; }

        public ServiceInfoPageModel(Repository.Repository repository, CookieService cookieService)
        {
            _repository = repository;
            _cookieService = cookieService;
        }
        public async Task OnGet(int id)
        {
            ServiceInfo = await _repository.GetService(id);
            IdClient = _cookieService.GetCookie("ClientData");
        }

        public async Task<IActionResult> OnPost(OrderServiceModel orderServiceModel)
        {
            if (!ModelState.IsValid)
            {
                ServiceInfo = await _repository.GetService((int)orderServiceModel.IdService);
                IdClient = _cookieService.GetCookie("ClientData");
                return Page();
            }

            orderServiceModel.IdClient = _cookieService.GetCookie("ClientData");
            await _repository.OrderService(orderServiceModel);

            return RedirectToPage("/OrdersPage");
        }
    }
}
