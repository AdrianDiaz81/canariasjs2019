using CanariasJS.Hooks.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanariasJS.Hooks.API.Domain
{
    public interface IAvengerDomain
    {
        Task<IEnumerable<Avengers>> GetAllAsync();
        Task<Avengers> GetByIdAsync(string id);
        Task<Avengers> InsertAsync(Avengers people);
        Task<bool> UpdateAsync(Avengers people);
        Task<bool> DeleteAsync(string id);
    }
}
