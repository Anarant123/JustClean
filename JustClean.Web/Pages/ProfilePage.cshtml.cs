using JustClean.Web.Models;
using JustClean.Web.Models.db;
using JustClean.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustClean.Web.Pages
{
    public class ProfilePageModel : PageModel
    {
        private readonly Repository.Repository _repository;
        public Client Client { get; set; }

        public ProfilePageModel(Repository.Repository repository)
        {
            _repository = repository;
        }
        public async Task OnGetAsync(int id)
        {
            Client = await _repository.GetClient(id);
        }
    }
}
