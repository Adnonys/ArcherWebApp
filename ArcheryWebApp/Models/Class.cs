using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcheryWebApp.Models
{
    [Table("ClassTable")]
    public class Class
    {
        [Key]
        public int ClassID { get; set; }
        public string ClassName { get; set; }
    }
}