﻿namespace ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Shared
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
