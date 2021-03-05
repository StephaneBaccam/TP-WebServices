using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP_DAL.Models;

namespace TP_DAL.Contrats
{
    public class AService<TModel> : IService<TModel> where TModel : IEntity
    {
        public IRepository<TModel> Repository { get; set; }
        public IOptions<AppSettingsModel> settings { get; set; }
        public AService(IRepository<TModel> repository, IOptions<AppSettingsModel> settings)
        {
            Repository = repository;
            this.settings = settings;
        }

        public Task<IEnumerable<TModel>> GetAllAsync()
        {
            return Repository.GetAllAsync();
        }

        public Task<TModel> GetByIdAsync(int id)
        {
            return Repository.GetByIdAsync(id);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return Repository.DeleteAsync(id);
        }

        public Task<bool> InsertAsync(TModel model)
        {
            return Repository.InsertAsync(model);
        }

        public Task<bool> UpdateAsync(TModel model)
        {
            return Repository.UpdateAsync(model);
        }
    }
}
