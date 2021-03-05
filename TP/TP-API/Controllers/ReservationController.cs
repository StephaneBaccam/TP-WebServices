using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_DAL.Entities;
using TP_DAL.Services.Interfaces;

namespace TP_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : AController<Reservation>
    {
        public ReservationController(IServiceReservation serviceReservation) : base(serviceReservation)
        {
            _serviceReservation = serviceReservation;
        }

        [HttpPost("creneau")]
        public async Task<IActionResult> ReservationCreneau([FromBody] Reservation reservation)
        {
            await _serviceReservation.InsertAsync(reservation);
            return Ok("Réservation confirmée");
        }
    }
}
