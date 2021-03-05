using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using TP_DAL.Contrats;
using TP_DAL.entities;
using TP_DAL.Models;

namespace TP_DAL.Providers
{
    public class DataProvidersArticle : ARepository<Article>, IRepositoryArticle
    {
        public DataProvidersArticle(IOptions<AppSettingsModel> settings) : base(settings)
        {

        }
        public override string SelectCommand => "SELECT * FROM Article";

        public override string SelectByIdCommand => "SELECT * FROM Article WHERE id = @id";

        public override string InsertCommand => 
            @"INSERT INTO Article
            (
                Nom
            )
            VALUES
            (
                @Nom
            )";

        public override string UpdateCommand =>
            @"UPDATE Article
            SET Nom = @Nom
            WHERE id = @id";

        public override string DeleteCommand => "DELETE FROM Article WHERE id = @id";
    }
}
