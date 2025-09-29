using Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Onboarding
{
    [Table("IPP_OnboardingHeader")]
    public class OnboardingHeader
    {
        [Key]
        public long Id { get; set; }
        public string FileName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FileTypes FileType { get; set; }
        public int RecordCount { get; set; }
        public string FileNumber { get; set; }
        public string Status { get; set; }
        public string? RejectReason { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CBFileName { get; set; }
        public string? ErrorCodeId { get; set; }
        public string? OnboardType { get; set; }
        public string? ControlFileName { get; set; }
        public int? SuccessCount { get; set; }
        public int? RejectCount { get; set; }
        public DateTime? CBResponseTime { get; set; }
    }

}
