using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Kuepf.HabrNewsTelegramBot.IoC.Interfaces
{
    public interface IBot
    {
        Task<TelegramBotClient> GetBotClientAsync();

        List<ICommand> commandsList { get; set; }
    }
}
