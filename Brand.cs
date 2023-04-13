using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrudOperationsInNetCore.Models
{
    public class Brands
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int brandId { get; set; }
        public int ModelId { get; set; }
        public int BrandDesId { get; set; }

        public Decimal Price { get; set; }
        public string? Name { get; set; }
       // public string? Category { get; set; }
       // public int  IsActive { get; set; }
    }
}
