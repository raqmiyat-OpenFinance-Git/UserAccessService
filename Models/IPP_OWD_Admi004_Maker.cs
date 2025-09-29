using System.ComponentModel.DataAnnotations;

namespace OpenFinanceWebApi.Models
{
    public class IPP_OWD_Admi004_Maker
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(35)]
        public string BICCode { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [Required]
        [StringLength(20)]
        public string RecordType { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool? Deleted { get; set; }

        public int? FCheckerId { get; set; }

        public DateTime? EvtTm { get; set; }
    }
}
