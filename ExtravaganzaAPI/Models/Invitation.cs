using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtravaganzaAPI.Models
{
    public class Invitation
    {
        public Guid? InvitationId { get; set; }
        public string Invitee { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? RSVPDueDate { get; set; }
        public DateTime? CreateTimestamp { get; set; }
        public DateTime? UpdateTimestamp { get; set; }
        public InvitationResponse[] Responses { get; set; }
    }
}
