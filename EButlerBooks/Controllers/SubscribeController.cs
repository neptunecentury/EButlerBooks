using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EButlerBooks.Models;
using EButlerBooks.Models.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EButlerBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {

        private readonly ILogger<SubscribeController> _logger;
        private readonly DbEntities _db;

        public SubscribeController(ILogger<SubscribeController> logger, DbEntities db)
        {
            _logger = logger;
            _db = db;
        }

        /// <summary>
        /// Subscribe
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("", Name = "Subscribe")]
        public async Task<IActionResult> Subscribe([FromForm] SubscribeRequestModel request)
        {
            
            // Check if the user is already subscribed
            var isSubscribed = _db.Subscriptions.Any(s => s.Email == request.Email);
            if (!isSubscribed)
            {
                // Save subscription
                var subscription = new Subscription()
                {
                    Email = request.Email
                };

                _db.Subscriptions.Add(subscription);
                await _db.SaveChangesAsync();
            }

            return Ok();
        }
    }
}