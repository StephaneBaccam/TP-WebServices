using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using TP_DAL.Contrats;
using TP_DAL.Entities;
using TP_DAL.Models;
using TP_DAL.Services.Interfaces;

namespace TP_DAL.Services
{
    public class ServiceMessage : AService<Message>, IServiceMessage
    {
        public ServiceMessage(IRepositoryMessage repositoryMessage, IOptions<AppSettingsModel> settings) : base(repositoryMessage, settings)
        {

        }
    }
}
