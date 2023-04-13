using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrudOperationsInNetCore.Models
{
    public class BrandInformation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int brandId { get; set; }
        public int BrandDesId { get; set; }
        public int ModelId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? ModelName { get; set; }
        public string? BrandDetails { get; set; }

    }
}
