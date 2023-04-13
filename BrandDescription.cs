using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrudOperationsInNetCore.Models
{
    public class BrandDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandDesId { get; set; }
        public int ModelId { get; set; }
       public string? BrandDetails { get; set; }
    }
}
