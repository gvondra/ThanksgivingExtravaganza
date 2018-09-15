using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface IInvitationResponse
    {
        int InvitationResponseId { get; }
        bool? IsAttending { get; }
        short? AttendeeCount { get; }
        string Note { get; }
        DateTime CreateTimestamp { get; }

        void Create(ITransactionHandler transactionHandler);
    }
}
