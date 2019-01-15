using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kuepf.HabrNewsTelegramBot.API.Services
{
    public interface IHabrScraper
    {
        Task<List<string>> GetPosts();
    }
}
