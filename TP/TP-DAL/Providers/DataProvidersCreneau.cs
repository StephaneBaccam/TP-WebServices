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
    public class DataProvidersCreneau : ARepository<Creneau>, IRepositoryCreneau
    {
        public DataProvidersCreneau(IOptions<AppSettingsModel> settings) : base(settings)
        {

        }
        public override string SelectCommand => "SELECT * FROM Creneau";

        public override string SelectByIdCommand => "SELECT * FROM Creneau WHERE id = @id";

        public override string InsertCommand =>
            @"INSERT INTO Creneau
            (
                date,
                commande_id
            )
            VALUES
            (
                @Date,
                @commande_id
            )";

        public override string UpdateCommand =>
            @"UPDATE Creneau
            SET date = @Date
            WHERE id = @id";

        public override string DeleteCommand => "DELETE FROM Creneau WHERE id = @id";

        public async Task<bool> CreateCreneau(List<DateTime> dates, int idCommande)
        {
            using IDbConnection connection = new MySqlConnection(_settings.ConnectionString);
            connection.Open();

            foreach(var date in dates)
            {
                Creneau Creneau = new Creneau();
                Creneau.Date = date;
                Creneau.commande_id = idCommande;
                await connection.ExecuteAsync(InsertCommand, Creneau);
            }

            return true;
        }

        public async Task<IEnumerable<Creneau>> GetListCreneauByIdCommande(int idCommande)
        {
            using IDbConnection connection = new MySqlConnection(_settings.ConnectionString);
            connection.Open();

            var request = @"SELECT * FROM Creneau WHERE commande_id = @idCommande";

            var creneaux = await connection.QueryAsync<Creneau>(request, new { idCommande });

            return creneaux;
        }
    }
}
