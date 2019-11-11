using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CanariasJS.API.Model;
using CanariasJS.Hooks.API.Domain;
using CanariasJS.Hooks.API.Model;
using Newtonsoft.Json.Linq;

namespace CanariasJS.Hooks.API.Service
{
       public class PatxaranService : IPatxaranService
    {

        IEnumerable<Patxaran> avengersCollection;
        private readonly IPatxaranDomain avengerDomain;
        public PatxaranService(IPatxaranDomain avengerDomain)
        {
            var dataCustomer = JObject.Parse(File.ReadAllText(@"./Data/patxaran.json"));
            var customerCollection = (JArray)dataCustomer["d"];
            avengersCollection = customerCollection.ToObject<IList<Patxaran>>();
            this.avengerDomain = avengerDomain;

        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(string id)
        {
            return await avengerDomain.DeleteAsync(id);
        }

        public bool Delete(string id)
        {
            return true;
        }
        public IEnumerable<Patxaran> GetAll()
        {
            return avengersCollection;
        }

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Patxaran>> GetAllAsync()
        {
            return await avengerDomain.GetAllAsync();
        }

        /// GetByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Patxaran> GetByIdAsync(string id)
        {
            return await avengerDomain.GetByIdAsync(id);
        }



        /// <summary>
        /// InsertAsync
        /// </summary>
        /// <param name="pastry"></param>
        /// <returns></returns>
        public async Task<Patxaran> InsertAsync(Patxaran people)
        {

            return await avengerDomain.InsertAsync(people);
        }

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="pastry"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Patxaran people)
        {
            return await avengerDomain.UpdateAsync(people);
        }

        public Patxaran GetById(string id)
        {
            return avengersCollection.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public bool Insert(Patxaran avengers)
        {
            return true;
        }

        public bool Update(Patxaran avengers)
        {
            return true;
        }
    }
}

