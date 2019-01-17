using Kuepf.HabrNewsTelegramBot.API.Services;
using Kuepf.HabrNewsTelegramBot.Datasource.Models;
using Kuepf.HabrNewsTelegramBot.IoC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Kuepf.HabrNewsTelegramBot.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MessageController : Controller
    {
        Types types;
        Objects postObj;

        private IHabrScraper _habrScraper;
        private IBot _bot;
        private TelegramBotContext _botDb;

        public MessageController(IHabrScraper habrScraper, IBot bot, TelegramBotContext context)
        {
            _habrScraper = habrScraper;
            _bot = bot;
            _botDb = context;
            types = new Types { Name = "string", ID = Guid.NewGuid() };
            postObj = new Objects { Name = "Posts", TypesID = types, ID = Guid.NewGuid() };
        }

        [HttpPost]
        public async Task<OkResult> Post([FromBody]Update update)
        {
            if (update == null) return Ok();

            var commands = _bot.commandsList;
            var message = update.Message;
            var botClient = await _bot.GetBotClientAsync();

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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await _botDb.Types.AddAsync(types);
            await _botDb.Objects.AddAsync(postObj);
            await _botDb.SaveChangesAsync();

            return Ok();
        }
    }
}
