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
    public class ServiceMagasin : AService<Magasin>, IServiceMagasin
    {
        public ServiceMagasin(IRepositoryMagasin repositoryMagasin, IOptions<AppSettingsModel> settings) : base(repositoryMagasin, settings)
        {

        }
    }
}
