using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Master
{
    [Table("Enrolment_Checker")]
    public class EnrolmentChecker
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Operation_Type { get; set; }

        [Required]
        [StringLength(100)]
        public string Operation_Desc { get; set; }

        public bool Enrolment_Status { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(2)]
        public string ShortName { get; set; }

        [StringLength(8)]
        public string UserType { get; set; }

        public int Approval_Status { get; set; }
    }
}
