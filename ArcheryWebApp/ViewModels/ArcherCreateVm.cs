using System.ComponentModel.DataAnnotations;

namespace ArcheryWebApp.ViewModels
{
    public class ArcherCreateVm
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName  { get; set; }

        [Required]
        public string Gender    { get; set; }

        [Required]
        public DateTime DOB     { get; set; }

        [Required]
        public int ClassID            { get; set; }

        [Required]
        public int DefaultDivisionID  { get; set; }

        [Required]
        public int DefaultEquipmentID { get; set; }
    }
}