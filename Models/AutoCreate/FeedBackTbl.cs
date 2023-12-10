using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class FeedBackTbl
    {
        public int FeedbackId { get; set; }
        public int? UserId { get; set; }
        public int? PropertyId { get; set; }
        public DateTime? FeedbackDate { get; set; }
        public string FeedbackText { get; set; }
        public decimal? Rating { get; set; }
        public string ResponseText { get; set; }
        public bool? Status { get; set; }

        public virtual PropertyTbl Property { get; set; }
        public virtual UserTbl User { get; set; }
    }
}
