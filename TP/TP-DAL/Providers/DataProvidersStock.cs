using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using TP_DAL.Contrats;
using TP_DAL.Entities;
using TP_DAL.Models;

namespace TP_DAL.Providers
{
    public class DataProvidersStock : ARepository<Stock>, IRepositoryStock
    {
        private readonly IRepositoryArticle _repositoryArticle;
        public DataProvidersStock(IOptions<AppSettingsModel> settings, IRepositoryArticle repositoryArticle) : base(settings)
        {
            _repositoryArticle = repositoryArticle;
        }
        public override string SelectCommand => "SELECT * FROM Stock";

        public override string SelectByIdCommand => "SELECT * FROM Stock WHERE id = @id";

        public override string InsertCommand =>
            @"INSERT INTO Stock
            (
                quantite,
                magasin_id,
                article_id
            )
            VALUES
            (
                @Quantite,
                @magasin_id,
                @article_id
            )";

        public override string UpdateCommand =>
            @"UPDATE Stock
            SET quantite = @Quantite,
            magasin_id = @magasin_id,
            article_id = @article_id
            WHERE id = @id";

        public override string DeleteCommand => "DELETE FROM Stock WHERE id = @id";

        public async Task<IEnumerable<int>> GetIdArticlesFromMagasin(int id)
        {
            using IDbConnection connection = new MySqlConnection(_settings.ConnectionString);
            connection.Open();

            string requestIdArticles = @"SELECT article_id
                                        FROM Stock st
                                        WHERE st.magasin_id = @id";

            var idArticles = await connection.QueryAsync<int>(requestIdArticles, new { id });
            return idArticles;
        }

        public async Task<IEnumerable<Stock>> GetStockFromArticle(int id)
        {
            using IDbConnection connection = new MySqlConnection(_settings.ConnectionString);
            connection.Open();

            string request = @"SELECT *
                             FROM Stock st
                             WHERE st.article_id = @id";

            var stock = await connection.QueryAsync<Stock>(request, new { id });
            return stock;
        }
    }
}
