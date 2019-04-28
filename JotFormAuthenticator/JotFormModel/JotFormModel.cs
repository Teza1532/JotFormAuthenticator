using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JotFormAuthenticator.Models
{
    public class JotFormModel
    {
        public long FormID { get; set; }
        public long SubmissionID { get; set; }
        public string Ip { get; set; }
        public string FormTitle { get; set; }
        public string Pretty { get; set; }
        public string Username { get; set; }
        public string RawRequest { get; set; }
        public string Type { get; set; }
    }
}
