using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DAL.Models;

namespace TP_DAL.Contrats
{
    public abstract class ARepository<TModel> : IRepository<TModel> where TModel : IEntity
    {
        public readonly AppSettingsModel _settings;
        public ARepository(IOptions<AppSettingsModel> settings)
        {
            _settings = settings.Value;
        }
        public abstract string SelectCommand
        {
            get;
        }

        public abstract string SelectByIdCommand
        {
            get;
        }

        public abstract string InsertCommand
        {
            get;
        }

        public abstract string UpdateCommand
        {
            get;
        }

        public abstract string DeleteCommand
        {
            get;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using IDbConnection connection = new MySqlConnection(_settings.ConnectionString);
            connection.Open();
            await connection.ExecuteAsync(DeleteCommand, new { id });
            return true;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            using IDbConnection connection = new MySqlConnection(_settings.ConnectionString);
            connection.Open();
            var res = await connection.QueryAsync<TModel>(SelectCommand);
            return res.ToList();
        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            using IDbConnection connection = new MySqlConnection(_settings.ConnectionString);
            connection.Open();
            var res = await connection.QueryAsync<TModel>(SelectByIdCommand, new { id });
            return res.First();
        }

        public async Task<bool> InsertAsync(TModel model)
        {
            using IDbConnection connection = new MySqlConnection(_settings.ConnectionString);
            connection.Open();
            await connection.ExecuteAsync(InsertCommand, model);
            return true;
        }

        public async Task<bool> UpdateAsync(TModel model)
        {
            using IDbConnection connection = new MySqlConnection(_settings.ConnectionString);
            connection.Open();
            await connection.ExecuteAsync(UpdateCommand, model);
            return true;
        }
    }
}
