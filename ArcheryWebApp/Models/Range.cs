using System.ComponentModel.DataAnnotations.Schema;
namespace ArcheryWebApp.Models
{
    [Table("RangeTable")]
    public class Range
    {
        public int RangeID { get; set; }
        public int RoundID { get; set; }
        public int Distance { get; set; }
        public int TargetFaceSize { get; set; }
        public int NumberOfEnds { get; set; }
        public int ArrowsPerEnd { get; set; }
        public int RangeOrder { get; set; }

        public Round Round { get; set; }
    }
}