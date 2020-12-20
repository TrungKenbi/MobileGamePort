using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileGamePort.Models
{
    public class GiftCode
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Mã Code")]
        public string Code { get; set; }
        [Display(Name = "Số Lượng")]
        public int Money { get; set; }
        [Display(Name = "Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; }

        public GiftCode()
        {
            this.CreatedAt = DateTime.UtcNow;
        }
    }
}
