using System;
using System.Collections.Generic;
using System.Text;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;

namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public interface IMenuDataSaver
    {
        void Create(ITransactionHandler transactionHandler, MenuData menuData);
        void Update(ITransactionHandler transactionHandler, MenuData menuData);
        void Delete(ITransactionHandler transactionHandler, int id);
    }
}
