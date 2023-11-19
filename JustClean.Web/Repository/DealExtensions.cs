using JustClean.Web.Models.db;
using Microsoft.EntityFrameworkCore;

namespace JustClean.Web.Repository
{
    public static class DealExtensions
    {
        public static async Task<List<Deal>> GetDeals(this Repository repository, int id)
        {
            var deals = await repository.context.Deals
                .Include(x => x.IdStatusNavigation)
                .Where(x => x.IdClient == id)
                .ToListAsync();
            if (deals is null) return null;

            return deals;
        }
    }
}
