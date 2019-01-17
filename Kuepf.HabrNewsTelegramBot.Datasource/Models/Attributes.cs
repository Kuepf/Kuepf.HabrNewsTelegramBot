using System;
using System.Collections.Generic;
using System.Text;

namespace Kuepf.HabrNewsTelegramBot.Datasource.Models
{
    public class Attributes : BaseEntity
    {
        public Types TypesID { get; set; }
        public string Name { get; set; }
    }
}
