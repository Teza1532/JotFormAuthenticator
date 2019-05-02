using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JotFormAuthenticator.Models
{
    public class FormModel : EntityBase
    {
        [Key]
        public int FormModelID { get; set; }
        [Required]
        public long FormID { get; set; }
        [Required]
        public string FormName { get; set; }
        [Required]
        public long SubmissionID { get; set; }
        public bool? Accepted { get; set; }
        public List<FieldModel> FormFields { get; set; }

    }
}
