using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CatalogService.Modesl
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ProductId")]
        public int ProductId { get; set; }

        [Column("ProductName")]
        public string ProductName { get; set; }
        [Column("Describe")]
        public string Describe { get; set; }


    }
}
