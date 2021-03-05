using System.Collections.Generic;
using System.Threading.Tasks;

namespace TP_DAL.Contrats
{
    public interface IService<TModel> where TModel : IEntity
    {
        IRepository<TModel> Repository { get; set; }
        Task<IEnumerable<TModel>> GetAllAsync();

        Task<TModel> GetByIdAsync(int id);

        Task<bool> DeleteAsync(int id);

        Task<bool> InsertAsync(TModel model);

        Task<bool> UpdateAsync(TModel model);
    }
}