using System;

namespace StudentApi.Models
{
    public class PromotionHistory
    {
        public int PromotionHistoryId { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int FromClassId { get; set; }
        public int ToClassId { get; set; }

        public DateTime PromotedAt { get; set; } = DateTime.Now;

        public int? PerformedByUserId { get; set; }
    }
}
