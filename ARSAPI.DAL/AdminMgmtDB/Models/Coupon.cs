using System;
using System.Collections.Generic;

namespace ARSAPI.DAL.Model
{
    public partial class Coupon
    {
        public int CouponId { get; set; }
        public string DicountCode { get; set; }
        public int DiscontCost { get; set; }
    }
}
