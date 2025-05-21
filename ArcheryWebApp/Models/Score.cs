using System;

namespace ArcheryWebApp.Models
{
    public class Score
    {
        public int ScoreID { get; set; }
        public int ArcherID { get; set; }
        public int RoundID { get; set; }
        public int EquipmentID { get; set; }
        public DateTime DateShot { get; set; }
        public int TotalScore { get; set; }
        public bool IsPractice { get; set; }
        public bool IsApproved { get; set; }
        public int? CompetitionID { get; set; }

        public Round Round { get; set; }
    }
}