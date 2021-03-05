using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using TP_DAL.Contrats;
using TP_DAL.Entities;
using TP_DAL.Models;

namespace TP_DAL.Providers
{
    public class DataProvidersMagasin : ARepository<Magasin>, IRepositoryMagasin
    {
        public DataProvidersMagasin(IOptions<AppSettingsModel> settings) : base(settings)
        {

        }
        public override string SelectCommand => "SELECT * FROM Magasin";

        public override string SelectByIdCommand => "SELECT * FROM Magasin WHERE id = @id";

        public override string InsertCommand =>
            @"INSERT INTO Magasin
            (
                Nom
            )
            VALUES
            (
                @Nom
            )";

        public override string UpdateCommand =>
            @"UPDATE Magasin
            SET Nom = @Nom
            WHERE id = @id";

        public override string DeleteCommand => "DELETE FROM Magasin WHERE id = @id";
    }
}
