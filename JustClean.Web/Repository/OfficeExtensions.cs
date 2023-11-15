using JustClean.Web.Models.db;
using Microsoft.EntityFrameworkCore;

namespace JustClean.Web.Repository
{
    public static class OfficeExtensions
    {
        public static async Task<List<Office>> GetOffices(this Repository repository)
        {
            var offices = await repository.context.Offices.ToListAsync();
            if (offices is null) return null;

            return offices;
        }
    }
}
