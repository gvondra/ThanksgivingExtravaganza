using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtravaganzaAPI.Models
{
    public class InvitationResponse
    {
        public int InvitationResponseId { get; set; }
        public bool? IsAttending { get; set; }
        public short? AttendeeCount { get; set; }
        public string Note { get; set; }
        public DateTime CreateTimestamp { get; set; }
    }
}
