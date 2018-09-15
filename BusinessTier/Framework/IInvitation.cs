using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface IInvitation
    {
        Guid InvitationId { get; }
        string Invitee { get; set; }
        string Title { get; set; }
        string Note { get; set; }
        DateTime EventDate { get; set; }
        DateTime RSVPDueDate { get; set; }
        DateTime CreateTimestamp { get; }
        DateTime UpdateTimestamp { get; }

        void Create(ITransactionHandler transactionHandler);
        void Update(ITransactionHandler transactionHandler);
        IEnumerable<IInvitationResponse> GetResponses(ISettings settings);
        IInvitationResponse CreateResponse(
            bool? isAttending,
            short? attendingCount,
            string note);
    }
}
