﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobileGamePort.Models
{
    public class GiftCodeUse
    {
        [Key, Column(Order = 0)]
        public int GiftCodeId { get; set; }
        [Key, Column(Order = 1)]
        public string UserId { get; set; }
    }
}
