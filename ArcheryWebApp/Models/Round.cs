using System;
using System.Collections.Generic;

namespace ArcheryWebApp.Models
{
    public class Round
    {
        public int RoundID { get; set; }
        public string RoundName { get; set; }
        public int TotalArrows { get; set; }
        public bool IsOfficial { get; set; }
        public DateTime DateEffectiveFrom { get; set; }

        public ICollection<Range> Ranges { get; set; }
    }
}