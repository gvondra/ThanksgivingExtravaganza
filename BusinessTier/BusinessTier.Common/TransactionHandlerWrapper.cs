using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Vondra.DataTier.Common;

namespace Vondra.Thanksgiving.Extravaganza.BusinessTier.Common
{
    public class TransactionHandlerWrapper : Vondra.DataTier.Common.ITransactionHandler
    {
        private Vondra.Thanksgiving.Extravaganza.Framework.ITransactionHandler m_innerTransactionHandler;

        public TransactionHandlerWrapper(Vondra.Thanksgiving.Extravaganza.Framework.ITransactionHandler transactionHandler)
        {
            m_innerTransactionHandler = transactionHandler;
        }

        public IDbConnection Connection
        {
            get => m_innerTransactionHandler.DatabaseConnection;
            set => m_innerTransactionHandler.DatabaseConnection = value;
        }
        public DataTier.Common.IDbTransaction Transaction
        {
            get => m_innerTransactionHandler.DatabaseTransaction;
            set => m_innerTransactionHandler.DatabaseTransaction = value;
        }

        public string ConnectionString
        {
            get
            {
                return m_innerTransactionHandler.ConnectionString;
            }
        }
    }
}
