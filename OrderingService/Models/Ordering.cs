using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderingService.Models
{
    public class Ordering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderingId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }

    }
}
