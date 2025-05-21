using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcheryWebApp.Models
{
    [Table("ArcherTable1")]
    public class Archer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArcherID { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Gender    { get; set; }
        public DateTime DOB     { get; set; }

        public int ClassID            { get; set; }
        public int DefaultDivisionID  { get; set; }
        
        public bool IsActive          { get; set; }

        // optional: navigation props nếu bạn có các bảng Class, Division
        // public Class Class { get; set; }
        // public Division DefaultDivision { get; set; }
        [Required] 
        public int DefaultEquipmentID { get; set; }
        public Equipment DefaultEquipment { get; set; }
    }
}