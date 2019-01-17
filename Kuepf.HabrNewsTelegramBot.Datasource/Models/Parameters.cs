using System;
using System.Collections.Generic;
using System.Text;

namespace Kuepf.HabrNewsTelegramBot.Datasource.Models
{
    public class Parameters : BaseEntity
    {
        public Objects ObjectID { get; set; }
        public Attributes AttributeID { get; set; }
        public string Value { get; set; }
    }
}
