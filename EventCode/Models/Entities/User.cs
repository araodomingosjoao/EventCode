using System;

namespace EventCode.Models.Entities
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BI { get; set; }
        public string QrCode { get; set; }
        public bool Status { get; set; }
        public DateTime Created_At { get; set; }

    }
}
