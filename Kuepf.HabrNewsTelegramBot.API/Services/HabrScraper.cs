using HtmlAgilityPack;
using Kuepf.HabrNewsTelegramBot.IoC.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kuepf.HabrNewsTelegramBot.API.Services
{
    public class HabrScraper : IHabrScraper
    {
        private string html = @"https://habr.com/page1/";
        private List<string> posts = new List<string>();
        
        public async Task<List<string>> GetPosts()
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//*[contains(@class,'post__title_link')]");

            foreach(var node in nodes)
            {
                if (node.Attributes["href"].Value.Contains("https://habr.com/post/"))
                {
                    posts.Add(node.Attributes["href"].Value);
                     // Write node to DB
                }
            }

            return await Task.FromResult(posts);
        }
    }
}
