using JustClean.Web.Models.db;

namespace JustClean.Web.Repository
{
    public class Repository
    {
        public readonly JustcleanContext context;
        public readonly ILogger<Repository> logger;

        public Repository(JustcleanContext context, ILogger<Repository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
