using System;
using System.Collections.Generic;
using System.Data;
using Vondra.Thanksgiving.Extravaganza.Framework;

namespace Vondra.Thanksgiving.Extravaganza.BusinessTier.Common
{
    public class Saver
    {
        public void Save(ITransactionHandler transactionHandler, Action<ITransactionHandler> save)
        {
            try
            {
                save(transactionHandler);
                if (transactionHandler.DatabaseTransaction != null)
                {
                    transactionHandler.DatabaseTransaction.Commit();
                }
                if (transactionHandler.DatabaseConnection != null 
                    && transactionHandler.DatabaseConnection.State == ConnectionState.Open)
                {
                    transactionHandler.DatabaseConnection.Close();
                }
            }
            catch
            {
                if (transactionHandler.DatabaseTransaction != null)
                {
                    transactionHandler.DatabaseTransaction.Rollback();
                }
                throw;
            }
            finally
            {
                if (transactionHandler.DatabaseTransaction != null)
                {
                    transactionHandler.DatabaseTransaction.Dispose();
                    transactionHandler.DatabaseTransaction = null;
                }
                if (transactionHandler.DatabaseConnection != null)
                {
                    transactionHandler.DatabaseConnection.Dispose();
                    transactionHandler.DatabaseConnection = null;
                }
            }
        }
    }
}
