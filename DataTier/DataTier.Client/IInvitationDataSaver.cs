using System;
using System.Collections.Generic;
using System.Text;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public interface IInvitationDataSaver
    {
        void Create(ITransactionHandler transactionHandler, InvitationData invitationData);
        void Update(ITransactionHandler transactionHandler, InvitationData invitationData);
        void Delete(ITransactionHandler transactionHandler, Guid invitationId);
    }
}
