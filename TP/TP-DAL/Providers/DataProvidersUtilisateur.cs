using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DAL.Contrats;
using TP_DAL.Entities;
using TP_DAL.Models;

namespace TP_DAL.Providers
{
    public class DataProvidersUtilisateur : ARepository<Utilisateur>, IRepositoryUtilisateur
    {
        public DataProvidersUtilisateur(IOptions<AppSettingsModel> settings) : base(settings)
        {

        }
        public override string SelectCommand => "SELECT * FROM Utilisateur";

        public override string SelectByIdCommand => "SELECT * FROM Utilisateur WHERE id = @id";

        public override string InsertCommand =>
            @"INSERT INTO Utilisateur
            (
                email,
                role,
                password
            )
            VALUES
            (
                @Email,
                @Role,
                @Password
            )";

        public override string UpdateCommand =>
            @"UPDATE Utilisateur
            SET email = @Email,
            role = @Role,
            password = @Password
            WHERE id = @id";

        public override string DeleteCommand => "DELETE FROM Utilisateur WHERE id = @id";

        public async Task<Utilisateur> GetUserByMail(string email)
        {
            using IDbConnection connection = new MySqlConnection(_settings.ConnectionString);
            connection.Open();
            var utilisateurs = await connection.QueryAsync<Utilisateur>(SelectCommand);
            var utilisateur = utilisateurs.Where(ut => ut.Email == email);
            if(!utilisateur.Any())
            {
                throw new Exception("Echec de la récupération de l'utilisateur");
            }
            else
            {
                return utilisateur.First();
            }
        }

        public async Task<string> GetUserPassword(string emailUtilisateur)
        {
            try
            {
                using IDbConnection connection = new MySqlConnection(_settings.ConnectionString);
                connection.Open();
                var utilisateurs = await connection.QueryAsync<Utilisateur>(SelectCommand);
                var utilisateur = utilisateurs.Where(ut => ut.Email == emailUtilisateur);
                var password = utilisateur.Select(ut => ut.Password).Take(1);

                return password.First();
            }
            catch
            {
                throw new Exception("Echec dans la récupération du mot de passe");
            }
        }
    }
}
