﻿namespace DubaiPhoneClone.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Percent { get; set; }

    }
}
