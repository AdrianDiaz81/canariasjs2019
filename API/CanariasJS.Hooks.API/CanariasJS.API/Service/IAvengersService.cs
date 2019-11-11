namespace CanariasJS.Hooks.API.Service
{
    using CanariasJS.Hooks.API.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAvengersService
    {
        IEnumerable<Avengers> GetAll();
        Avengers GetById(string id);
        bool Insert(Avengers avengers);
        bool Update(Avengers avengers);
        bool Delete(string id);

        Task<IEnumerable<Avengers>> GetAllAsync();
        Task<Avengers> GetByIdAsync(string id);
        Task<Avengers> InsertAsync(Avengers people);
        Task<bool> UpdateAsync(Avengers people);
        Task<bool> DeleteAsync(string id);
    }
}
