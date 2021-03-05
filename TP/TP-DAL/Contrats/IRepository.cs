using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TP_DAL.Contrats
{
    public interface IRepository<TModel> where TModel : IEntity
    {
        Task<IEnumerable<TModel>> GetAllAsync();

        Task<TModel> GetByIdAsync(int id);

        Task<bool> DeleteAsync(int id);

        Task<bool> UpdateAsync(TModel model);

        Task<bool> InsertAsync(TModel model);
    }
}
