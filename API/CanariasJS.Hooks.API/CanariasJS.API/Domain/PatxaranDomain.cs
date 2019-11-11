namespace CanariasJS.Hooks.API.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CanariasJS.API.Model;
    using CanariasJS.Hooks.API.Repository;
    public class PatxaranDomain : IPatxaranDomain
    {
        private readonly IPatxaranRepository avengerRepository;

        public PatxaranDomain(IPatxaranRepository avengerRepository)
        {
            this.avengerRepository = avengerRepository;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            return await avengerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Patxaran>> GetAllAsync()
        {
            return await avengerRepository.GetAsync();
        }

        public async Task<Patxaran> GetByIdAsync(string id)
        {
            return await avengerRepository.GetByIdAsync(id);
        }

        public async Task<Patxaran> InsertAsync(Patxaran people)
        {
            return await avengerRepository.AddAsync(people);
        }

        public async Task<bool> UpdateAsync(Patxaran people)
        {
            return await avengerRepository.UpdateAsync(people);
        }
    }
}
