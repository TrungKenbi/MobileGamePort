using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileGamePort.Models
{
    public class User : IdentityUser
    {
        // Họ và Tên
        [PersonalData]
        public string Fullname { get; set; }
        // Xu
        [PersonalData]
        [DefaultValue(0)]
        public int Coin { get; set; }
        // Lượng
        [PersonalData]
        [DefaultValue(0)]
        public int Gold { get; set; }

        public ICollection<Recharge> recharges { get; set; }
    }
}
