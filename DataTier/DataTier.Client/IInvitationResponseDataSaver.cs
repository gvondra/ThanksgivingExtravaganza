using System;
using System.Collections.Generic;
using System.Text;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public interface IInvitationResponseDataSaver
    {
        void Create(ITransactionHandler transactionHandler, InvitationResponseData responseData);
    }
}
