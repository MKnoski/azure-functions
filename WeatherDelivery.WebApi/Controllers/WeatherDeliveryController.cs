﻿using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherDelivery.Sdk.Models;

namespace WeatherDelivery.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherDeliveryController : ControllerBase
    {
        private readonly ILogger<WeatherDeliveryController> _logger;
        private readonly IMediator _mediator;

        public WeatherDeliveryController(IMediator mediator, ILogger<WeatherDeliveryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InitWeatherDelivery(Delivery delivery)
        {
            _logger.LogInformation($"Weather delivery init - id: {delivery.Id}");

            delivery.Id = Guid.NewGuid();

            await _mediator.Send(delivery);

            return Ok();
        }
    }
}