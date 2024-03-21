using System.Text.Json.Serialization;

namespace DubaiPhoneClone.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public string ArabicName { get; set; }= string.Empty;
        public string ImagePath { get; set; }= string.Empty;
        [JsonIgnore]
        public List<Product>? Products { get; set; }


    }
}
