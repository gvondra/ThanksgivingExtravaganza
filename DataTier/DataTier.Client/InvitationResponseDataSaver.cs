using System;
using System.Collections.Generic;
using System.Data;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public class InvitationResponseDataSaver : IInvitationResponseDataSaver
    {
        public void Create(ITransactionHandler transactionHandler, InviationResponseData responseData)
        {
            Create(transactionHandler, new DbProviderFactory(), responseData);
        }
        public void Create(ITransactionHandler transactionHandler, IDbProviderFactory providerFactory, InviationResponseData responseData)
        {
            if (responseData.DataStateManager.GetState(responseData) == DataStateManagerState.New)
            {
                providerFactory.EstablishTransaction(transactionHandler, responseData);
                using (IDbCommand command = transactionHandler.Connection.CreateCommand())
                {
                    command.CommandText = "vte.ISP_InvitationResponse";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transactionHandler.Transaction.InnerTransaction;

                    IDataParameter id = Util.CreateParameter(providerFactory, "id", DbType.Int32);
                    id.Direction = ParameterDirection.Output;
                    command.Parameters.Add(id);

                    IDataParameter timestamp = Util.CreateParameter(providerFactory, "timestamp", DbType.DateTime);
                    timestamp.Direction = ParameterDirection.Output;
                    command.Parameters.Add(timestamp);

                    Util.AddParameter(providerFactory, command.Parameters, "invitationId", DbType.Guid, Util.GetParameterValue(responseData.InvitationId));
                    Util.AddParameter(providerFactory, command.Parameters, "isAttending", DbType.Boolean, Util.GetParameterValue(responseData.IsAttending));
                    Util.AddParameter(providerFactory, command.Parameters, "attendeeCount", DbType.Int16, Util.GetParameterValue(responseData.AttendeeCount));
                    Util.AddParameter(providerFactory, command.Parameters, "note", DbType.String, Util.GetParameterValue(responseData.Note));

                    command.ExecuteNonQuery();

                    responseData.InvitationResponseId = (int)id.Value;
                    responseData.CreateTimestamp = (DateTime)timestamp.Value;
                }
            }
        }
    }
}
