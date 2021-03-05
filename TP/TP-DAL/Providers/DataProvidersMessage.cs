using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using TP_DAL.Contrats;
using TP_DAL.Entities;
using TP_DAL.Models;

namespace TP_DAL.Providers
{
    public class DataProvidersMessage : ARepository<Message>, IRepositoryMessage
    {
        public DataProvidersMessage(IOptions<AppSettingsModel> settings) : base(settings)
        {

        }
        public override string SelectCommand => "SELECT * FROM Message";

        public override string SelectByIdCommand => "SELECT * FROM Message WHERE id = @id";

        public override string InsertCommand =>
            @"INSERT INTO Message
            (
                message_to_id,
                message
            )
            VALUES
            (
                @MessageToId,
                @TextMessage
            )";

        public override string UpdateCommand =>
            @"UPDATE Message
            SET message_to_id = @MessageToId,
            message = @TextMessage
            WHERE id = @id";

        public override string DeleteCommand => "DELETE FROM Message WHERE id = @id";
    }
}
