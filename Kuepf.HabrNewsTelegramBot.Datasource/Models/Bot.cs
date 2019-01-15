using Kuepf.HabrNewsTelegramBot.Datasource.Commands;
using Kuepf.HabrNewsTelegramBot.IoC.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Kuepf.HabrNewsTelegramBot.Datasource.Models
{
    public class Bot : IBot
    {
        private TelegramBotClient botClient;

        public List<ICommand> commandsList { get; set; }
        public async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<ICommand>();
            commandsList.Add(new StartCommand());
            //TODO: Add more commands

            botClient = new TelegramBotClient(AppSettings.Key);
            string hook = string.Format(AppSettings.Url, "api/message/update");
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }
    }
}
