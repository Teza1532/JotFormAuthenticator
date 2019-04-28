using JotFormAuthenticator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JotFormAuthenticator.Models
{
    public class FieldModel : EntityBase
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int FieldID { get; set; }
        public string FieldParentName{ get; set; }
        [Required]
        public string FieldName { get; set; }
        [Required]
        public string FieldValue { get; set; }
        [Required]
        public long SubmissionID { get; set; }

        [ForeignKey("FormID")]
        public FormModel Form { get; set; }
    }
}
