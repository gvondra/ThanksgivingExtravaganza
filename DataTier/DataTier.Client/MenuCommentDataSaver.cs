using System;
using System.Collections.Generic;
using System.Data;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;

namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public class MenuCommentDataSaver : IMenuCommentDataSaver
    {
        public void Create(ITransactionHandler transactionHandler, MenuCommentData commentData)
        {
            Create(transactionHandler, new DbProviderFactory(), commentData);
        }
        public void Create(ITransactionHandler transactionHandler, IDbProviderFactory providerFactory, MenuCommentData commentData)
        {
            providerFactory.EstablishTransaction(transactionHandler, commentData);
            using (IDbCommand command = transactionHandler.Connection.CreateCommand())
            {
                command.CommandText = "vte.ISP_MenuComment";
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transactionHandler.Transaction.InnerTransaction;

                IDataParameter id = Util.CreateParameter(providerFactory, "id", DbType.Int32);
                id.Direction = ParameterDirection.Output;
                command.Parameters.Add(id);

                IDataParameter timestamp = Util.CreateParameter(providerFactory, "timestamp", DbType.DateTime);
                timestamp.Direction = ParameterDirection.Output;
                command.Parameters.Add(timestamp);

                Util.AddParameter(providerFactory, command.Parameters, "menuId", DbType.Int32, Util.GetParameterValue(commentData.MenuId));
                Util.AddParameter(providerFactory, command.Parameters, "text", DbType.String, Util.GetParameterValue(commentData.Text));
                Util.AddParameter(providerFactory, command.Parameters, "createUser", DbType.String, Util.GetParameterValue(commentData.CreateUser));

                command.ExecuteNonQuery();

                commentData.MenuCommentId = (int)id.Value;
                commentData.CreateTimestamp = (DateTime)timestamp.Value;
            }
        }
    }
}
