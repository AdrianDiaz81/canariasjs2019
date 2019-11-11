using CanariasJS.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanariasJS.Hooks.API.Domain
{
    public interface IPatxaranDomain
    {
        Task<IEnumerable<Patxaran>> GetAllAsync();
        Task<Patxaran> GetByIdAsync(string id);
        Task<Patxaran> InsertAsync(Patxaran people);
        Task<bool> UpdateAsync(Patxaran people);
        Task<bool> DeleteAsync(string id);
    }
}
