﻿namespace DubaiPhoneClone.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int PordId { get; set; }
        public string Path { get; set; } = string.Empty;

        public Product Product { get; set; }
    }
}
