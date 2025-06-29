using System.ComponentModel.DataAnnotations;

namespace Dist2806
{
    public class Materialss
    {
        public int Material_ID { get; set; }
        [Required]
        public string Material_Name { get; set; }
        [Required]
        public decimal Material_Cost { get; set; } 
    }
}
