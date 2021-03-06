﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileGamePort.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tên game")]
        public string Name { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }
        [Display(Name = "Link tải Android")]
        public string LinkAndroid { get; set; }
        [Display(Name = "Link tải iOS")]
        public string LinkIOS { get; set; }
        [Display(Name = "Lượt xem")]
        public int Views { get; set; }
        [Display(Name = "Lượt tải")]
        public int Downloads { get; set; }
    }
}
