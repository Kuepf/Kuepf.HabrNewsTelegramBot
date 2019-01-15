using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kuepf.HabrNewsTelegramBot.IoC.Interfaces
{
    public interface IHabrScraper
    {
        Task<List<string>> GetPosts();
    }
}
