using System;
using System.Collections.Generic;
using System.Text;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;

namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public interface IMenuCommentDataSaver
    {
        void Create(ITransactionHandler transactionHandler, MenuCommentData commentData);
    }
}
