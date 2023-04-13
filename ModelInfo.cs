using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperationsInNetCore.Models
{
    public class ModelInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelId { get; set; }
        public string? ModelName { get; set; }
        public int brandId { get; set; }
    }
}
