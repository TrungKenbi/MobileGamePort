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
        public int Amount { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
