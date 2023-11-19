using JustClean.Web.Models;
using JustClean.Web.Models.db;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

namespace JustClean.Web.Repository
{
    public static class ServiceExtensions
    {
        public static async Task<List<JustClean.Web.Models.db.Service>> GetServices(this Repository repository)
        {
            var services = await repository.context.Services.ToListAsync();

            return services;
        }

        public static async Task<JustClean.Web.Models.db.Service> GetService(this Repository repository, int id)
        {
            var service = await repository.context.Services.FirstOrDefaultAsync(x => x.Id == id);

            return service;
        }

        public static async Task OrderService(this Repository repository, OrderServiceModel orderServiceModel)
        {
            var service = repository.context.Services
                .Include(x => x.Office)
                .FirstOrDefault(x => x.Id == orderServiceModel.IdService);
            var client = repository.context.Clients.FirstOrDefault(x => x.Id == orderServiceModel.IdClient);

            var deal = new Deal
            {
                Name = service.Name,
                Cost = service.Price,
                Street = orderServiceModel.Street,
                House = orderServiceModel.House,
                Flat = orderServiceModel.Flat,
                CreateDate = DateTime.Now.Date,
                ProvisionDate = orderServiceModel.ProvisionDate,
                Description = orderServiceModel.Description,
                IdStatus = 1, 
                IdClient = client.Id,
                IdOffice = service.OfficeId,
                IdService = service.Id,
            };

            repository.context.Deals.Add(deal);
            await repository.context.SaveChangesAsync();
        } 

    }
}
