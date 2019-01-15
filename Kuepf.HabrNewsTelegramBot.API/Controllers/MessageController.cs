﻿using Kuepf.HabrNewsTelegramBot.API.Services;
using Kuepf.HabrNewsTelegramBot.Datasource.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Kuepf.HabrNewsTelegramBot.API.Controllers
{
    [Route("api/message/update")]
    public class MessageController : Controller
    {
        private IHabrScraper _habrScraper;

        public MessageController(IHabrScraper habrScraper)
        {
            _habrScraper = habrScraper;
        }

        [HttpPost]
        public async Task<OkResult> Post([FromBody]Update update)
        {
            if (update == null) return Ok();

            var commands = Bot.Commands;
            var message = update.Message;
            var botClient = await Bot.GetBotClientAsync();

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, botClient);
                    break;
                }
            }
            return Ok();
        }

        [HttpGet]
        public async Task<List<string>> Get()
        {
            return await _habrScraper.GetPosts();
        }
    }
}
