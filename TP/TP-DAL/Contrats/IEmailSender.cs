using System;
using System.Collections.Generic;
using System.Text;
using TP_DAL.Models;

namespace TP_DAL.Contrats
{
    public interface IEmailSender
    {
        void SendEmail(MailMessage message);
    }
}
