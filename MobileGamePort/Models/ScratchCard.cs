using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileGamePort.Models
{
    public class ScratchCard
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tài khoản")]
        public User User { get; set; }
        [Display(Name = "Mã giao dịch")]
        public string RequestId { get; set; }
        [Display(Name = "Nhà mạng")]
        public string Telco { get; set; }
        [Display(Name = "Mệnh giá")]
        public int Amount { get; set; }
        [Display(Name = "Số sê ri")]
        public string Serial { get; set; }
        [Display(Name = "Mã thẻ")]
        public string Code { get; set; }
        [Display(Name = "Lượng nhận được")]
        public int Money { get; set; }
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }
        [Display(Name = "Ngày nạp")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; }

        public ScratchCard()
        {
            this.Status = 0;
            this.CreatedAt = DateTime.UtcNow;
        }
    }
}
