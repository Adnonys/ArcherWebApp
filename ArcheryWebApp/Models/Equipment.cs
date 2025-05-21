using System.ComponentModel.DataAnnotations.Schema;

namespace ArcheryWebApp.Models
{
    [Table("EquipmentTable")]
    public class Equipment
    {
        public int EquipmentID { get; set; }
        public string EquipmentName { get; set; }
    }
}