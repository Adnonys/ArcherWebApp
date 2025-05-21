using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcheryWebApp.Models
{
    [Table("DivisionTable")]
    public class Division
    {
        [Key]
        public int DivisionID { get; set; }
        public string DivisionName { get; set; }
    }
}