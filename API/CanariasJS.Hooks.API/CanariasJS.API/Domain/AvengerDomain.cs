namespace CanariasJS.Hooks.API.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CanariasJS.Hooks.API.Model;
    using CanariasJS.Hooks.API.Repository;
    public class AvengerDomain : IAvengerDomain
    {
        private readonly IAvengerRepository avengerRepository;

        public AvengerDomain(IAvengerRepository avengerRepository)
        {
            this.avengerRepository = avengerRepository;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            return await avengerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Avengers>> GetAllAsync()
        {
            return await avengerRepository.GetAsync();
        }

        public async Task<Avengers> GetByIdAsync(string id)
        {
            return await avengerRepository.GetByIdAsync(id);
        }

        public async Task<Avengers> InsertAsync(Avengers people)
        {
            return await avengerRepository.AddAsync(people);
        }

        public async Task<bool> UpdateAsync(Avengers people)
        {
            return await avengerRepository.UpdateAsync(people);
        }
    }
}
