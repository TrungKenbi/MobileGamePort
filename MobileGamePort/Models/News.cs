using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileGamePort.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Thumbnail { get; set; }
        public User Author { get; set; }
        [Display(Name = "Ngày đăng")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; }

        public News()
        {
            this.CreatedAt = DateTime.UtcNow;
        }
    }
}
