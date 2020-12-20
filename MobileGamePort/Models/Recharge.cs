using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileGamePort.Models
{
    public class Recharge
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public int Amount { get; set; }
        public string Type { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public int Money { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; }

        public Recharge()
        {
            this.CreatedAt = DateTime.UtcNow;
        }
    }
}
