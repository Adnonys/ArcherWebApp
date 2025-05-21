using System;

namespace ArcheryWebApp.Models
{
    public class ScoreStaging
    {
        public int ScoreStagingID { get; set; }
        public int ArcherID { get; set; }
        public int RoundID { get; set; }
        public int EquipmentID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public bool IsPractice { get; set; }
        public bool IsCompetition { get; set; }
    }
}