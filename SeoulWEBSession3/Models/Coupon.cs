﻿using System;
using System.Collections.Generic;

namespace SeoulWEBSession3.Models;

public partial class Coupon
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string CouponCode { get; set; } = null!;

    public decimal DiscountPercent { get; set; }

    public decimal MaximimDiscountAmount { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
