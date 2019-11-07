namespace CanariasJS.Hooks.API.Repository
{
    using CanariasJS.Hooks.API.Data;
    using CanariasJS.Hooks.API.Model;
    using Microsoft.Extensions.Logging;
    public class AvengerRepository : RepositoryBase<Avengers>, IAvengerRepository
    {
        public AvengerRepository(ILogger logger, AvengerDbContext dataContext) : base(logger, dataContext)
        {
        }
    }
}
