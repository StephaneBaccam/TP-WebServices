﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_DAL.Entities;
using TP_DAL.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagasinController : AController<Magasin>
    {
        public MagasinController(IServiceMagasin serviceMagasin) : base(serviceMagasin)
        {

        }
    }
}
