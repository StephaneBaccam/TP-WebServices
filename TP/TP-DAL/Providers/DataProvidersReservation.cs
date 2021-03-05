using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using TP_DAL.Contrats;
using TP_DAL.Entities;
using TP_DAL.Models;

namespace TP_DAL.Providers
{
    public class DataProvidersReservation : ARepository<Reservation>, IRepositoryReservation
    {
        public DataProvidersReservation(IOptions<AppSettingsModel> settings) : base(settings)
        {

        }
        public override string SelectCommand => "SELECT * FROM Reservation";

        public override string SelectByIdCommand => "SELECT * FROM Reservation WHERE id = @id";

        public override string InsertCommand =>
            @"INSERT INTO Reservation
            (
                creneau_id,
                utilisateur_id
            )
            VALUES
            (
                @creneau_id,
                @utilisateur_id
            )";

        public override string UpdateCommand =>
            @"UPDATE Reservation
            SET creneau_id = @creneau_id,
            utilisateur_id = @utilisateur_id
            WHERE id = @id";

        public override string DeleteCommand => "DELETE FROM Reservation WHERE id = @id";
    }
}
