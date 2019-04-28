using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JotFormAuthenticator.Models
{
    public class FormModel : EntityBase
    {
        [Key]
        public long FormID { get; set; }
        [Required]
        public string FormName { get; set; }
        [Required]
        public long SubmissionID { get; set; }
        public ICollection<FieldModel> FormFields { get; set; }
    }
}
