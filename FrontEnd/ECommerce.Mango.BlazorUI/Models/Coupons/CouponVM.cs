﻿namespace ECommerce.Mango.BlazorUI.Models.Coupons
{
    public class CouponVM
    {
        public int Id { get; set; }
        public string CouponCode { get; set; } = null!;
        public double DiscountAmount { get; set; }
        public int MinimumAmount { get; set; }
    }
}
