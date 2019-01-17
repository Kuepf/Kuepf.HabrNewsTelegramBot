using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kuepf.HabrNewsTelegramBot.Datasource.Models
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
    }
}
