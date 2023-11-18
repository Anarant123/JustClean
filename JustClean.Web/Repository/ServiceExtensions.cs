using Microsoft.EntityFrameworkCore;

namespace JustClean.Web.Repository
{
    public static class ServiceExtensions
    {
        public static async Task<List<JustClean.Web.Models.db.Service>> GetService(this Repository repository)
        {
            var services = await repository.context.Services.ToListAsync();

            return services;
        }
    }
}
