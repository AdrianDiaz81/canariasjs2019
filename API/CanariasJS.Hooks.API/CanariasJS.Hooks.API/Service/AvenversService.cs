using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CanariasJS.Hooks.API.Domain;
using CanariasJS.Hooks.API.Model;
using Newtonsoft.Json.Linq;

namespace CanariasJS.Hooks.API.Service
{
       public class AvengersService : IAvengersService
    {

        IEnumerable<Avengers> avengersCollection;
        private readonly IAvengerDomain avengerDomain;
        public AvengersService(IAvengerDomain avengerDomain)
        {
            var dataCustomer = JObject.Parse(File.ReadAllText(@"./Data/avengers.json"));
            var customerCollection = (JArray)dataCustomer["d"];
            avengersCollection = customerCollection.ToObject<IList<Avengers>>();
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
        public IEnumerable<Avengers> GetAll()
        {
            return avengersCollection;
        }

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Avengers>> GetAllAsync()
        {
            return await avengerDomain.GetAllAsync();
        }

        /// GetByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Avengers> GetByIdAsync(string id)
        {
            return await avengerDomain.GetByIdAsync(id);
        }



        /// <summary>
        /// InsertAsync
        /// </summary>
        /// <param name="pastry"></param>
        /// <returns></returns>
        public async Task<Avengers> InsertAsync(Avengers people)
        {

            return await avengerDomain.InsertAsync(people);
        }

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="pastry"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Avengers people)
        {
            return await avengerDomain.UpdateAsync(people);
        }

        public Avengers GetById(string id)
        {
            return avengersCollection.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public bool Insert(Avengers avengers)
        {
            return true;
        }

        public bool Update(Avengers avengers)
        {
            return true;
        }
    }
}

