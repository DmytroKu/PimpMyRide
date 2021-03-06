﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PimpMyRide.Domain.FileStorage;

namespace PimpMyRide.ServerApp
{
    [ApiController]
    [Route("api/game")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private static ServerGameService gameService;


        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        [HttpPost("run")]
        [HttpGet("run")]
        public Task Run()
        {
            _logger.LogInformation("run");
            gameService = new ServerGameService(new FileRepository());
            Task.Run(() => gameService.Run());
            return Task.CompletedTask;
        }

        [HttpPost("choice")]
        [HttpGet("choice")]
        public Task MakeChoice(int choice)
        {
            _logger.LogInformation("choice");
            gameService.SaveChoice(choice);
            return Task.CompletedTask;
        }

        [HttpGet("info")]
        public Task<string[]> GetInfo()
        {
            _logger.LogInformation("info");
            return Task.FromResult(gameService.GetInfo());
        } 
    }
}