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
    public class DataProvidersCommande : ARepository<Commande>, IRepositoryCommande
    {
        public DataProvidersCommande(IOptions<AppSettingsModel> settings) : base(settings)
        {

        }
        public override string SelectCommand => "SELECT * FROM Commande";

        public override string SelectByIdCommand => "SELECT * FROM Commande id = @id";

        public override string InsertCommand =>
            @"INSERT INTO Commande
            (
                utilisateur_id,
                stock_id,
                quantite
            )
            VALUES
            (
                @utilisateur_id,
                @stock_id,
                @Quantite
            )";

        public override string UpdateCommand =>
            @"UPDATE Commande
            SET utilisateur_id = @utilisateur_id,
            stock_id = @stock_id,
            quantite = @Quantite
            WHERE id = @id";

        public override string DeleteCommand => "DELETE FROM Commande WHERE id = @id";
    }
}
