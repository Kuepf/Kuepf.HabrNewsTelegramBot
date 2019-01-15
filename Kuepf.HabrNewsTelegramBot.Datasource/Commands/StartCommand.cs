﻿using Kuepf.HabrNewsTelegramBot.IoC.Interfaces;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Kuepf.HabrNewsTelegramBot.Datasource.Commands
{
    public class StartCommand : ICommand
    {
        public string Name => @"/start";

        public bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, "Hallo I'm HabrNewsBot made by Kuepf", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
