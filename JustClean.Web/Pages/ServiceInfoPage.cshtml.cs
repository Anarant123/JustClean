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
        [BindProperty]
        public JustClean.Web.Models.db.Service ServiceInfo { get; set; }
        [BindProperty]
        public OrderServiceModel OrderServiceModel { get; set; }

        public ServiceInfoPageModel(Repository.Repository repository, CookieService cookieService)
        {
            _repository = repository;
            _cookieService = cookieService;
        }
        public async Task OnGet(int id)
        {
            ServiceInfo = await _repository.GetService(id);
        }

        public async Task OnPost(OrderServiceModel orderServiceModel)
        {
            orderServiceModel.IdClient = _cookieService.GetCookie("ClientData");
            await _repository.OrderService(orderServiceModel);
        }
    }
}
