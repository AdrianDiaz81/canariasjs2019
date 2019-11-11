namespace CanariasJS.Hooks.API.Service
{
    using CanariasJS.API.Model;
    using CanariasJS.Hooks.API.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPatxaranService
    {
        IEnumerable<Patxaran> GetAll();
        Patxaran GetById(string id);
        bool Insert(Patxaran avengers);
        bool Update(Patxaran avengers);
        bool Delete(string id);

        Task<IEnumerable<Patxaran>> GetAllAsync();
        Task<Patxaran> GetByIdAsync(string id);
        Task<Patxaran> InsertAsync(Patxaran people);
        Task<bool> UpdateAsync(Patxaran people);
        Task<bool> DeleteAsync(string id);
    }
}
