namespace CanariasJS.Hooks.API.Repository
{
    using CanariasJS.API.Model;
    using CanariasJS.Hooks.API.Data;
    using Microsoft.Extensions.Logging;
    public class PatxaranRepository : RepositoryBase<Patxaran>, IPatxaranRepository
    {
        public PatxaranRepository(ILogger logger, AvengerDbContext dataContext) : base(logger, dataContext)
        {
        }
    }
}
