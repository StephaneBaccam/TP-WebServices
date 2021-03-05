using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using TP_DAL.Contrats;
using TP_DAL.entities;
using TP_DAL.Models;
using TP_DAL.Services.Interfaces;

namespace TP_DAL.Services
{
    public class ServiceArticle : AService<Article>, IServiceArticle
    {
        public ServiceArticle(IRepositoryArticle repositoryArticle, IOptions<AppSettingsModel> settings) : base(repositoryArticle, settings)
        {

        }
    }
}
