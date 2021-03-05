using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_DAL.Contrats;

namespace TP_API.Controllers
{
    public interface IController<TModel> where TModel : IEntity
    {
        Task<IEnumerable<TModel>> GetAllAsync();

        Task<TModel> GetByIdAsync(int id);

        Task<IActionResult> DeleteAsync(int id);

        Task<IActionResult> UpdateAsync(TModel model);

        Task<IActionResult> InsertAsync(TModel model);
    }
}
