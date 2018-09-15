using System;
using System.Collections.Generic;
using System.Data;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public class InvitationDataSaver : IInvitationDataSaver
    {
        public void Create(ITransactionHandler transactionHandler, InvitationData invitationData)
        {
            Create(transactionHandler, new DbProviderFactory(), invitationData);
        }

        public void Create(ITransactionHandler transactionHandler, IDbProviderFactory providerFactory, InvitationData invitationData)
        {
            if (invitationData.DataStateManager.GetState(invitationData) == DataStateManagerState.New)
            {
                providerFactory.EstablishTransaction(transactionHandler, invitationData);
                using (IDbCommand command = transactionHandler.Connection.CreateCommand())
                {
                    command.CommandText = "vte.ISP_Invitation";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transactionHandler.Transaction.InnerTransaction;

                    IDataParameter timestamp = Util.CreateParameter(providerFactory, "timestamp", DbType.DateTime);
                    timestamp.Direction = ParameterDirection.Output;
                    command.Parameters.Add(timestamp);

                    Util.AddParameter(providerFactory, command.Parameters, "id", DbType.Guid, Util.GetParameterValue(invitationData.InvitationId));
                    Util.AddParameter(providerFactory, command.Parameters, "invitee", DbType.String, Util.GetParameterValue(invitationData.Invitee));
                    Util.AddParameter(providerFactory, command.Parameters, "title", DbType.String, Util.GetParameterValue(invitationData.Title));
                    Util.AddParameter(providerFactory, command.Parameters, "note", DbType.String, Util.GetParameterValue(invitationData.Note));
                    Util.AddParameter(providerFactory, command.Parameters, "eventDate", DbType.Date, Util.GetParameterValue(invitationData.EventDate));
                    Util.AddParameter(providerFactory, command.Parameters, "rsvpDue", DbType.Date, Util.GetParameterValue(invitationData.RSVPDueDate));

                    command.ExecuteNonQuery();

                    invitationData.CreateTimestamp = (DateTime)timestamp.Value;
                    invitationData.UpdateTimestamp = (DateTime)timestamp.Value;
                }
            }
        }

        public void Delete(ITransactionHandler transactionHandler, Guid invitationId)
        {
            Delete(transactionHandler, new DbProviderFactory(), invitationId);
        }

        public void Delete(ITransactionHandler transactionHandler, IDbProviderFactory providerFactory, Guid invitationId)
        {
            providerFactory.EstablishTransaction(transactionHandler);
            using (IDbCommand command = transactionHandler.Connection.CreateCommand())
            {
                command.CommandText = "vte.DSP_Invitation";
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transactionHandler.Transaction.InnerTransaction;

                Util.AddParameter(providerFactory, command.Parameters, "id", DbType.Guid, Util.GetParameterValue(invitationId));

                command.ExecuteNonQuery();
            }            
        }

        public void Update(ITransactionHandler transactionHandler, InvitationData invitationData)
        {
            Update(transactionHandler, new DbProviderFactory(), invitationData);
        }

        public void Update(ITransactionHandler transactionHandler, IDbProviderFactory providerFactory, InvitationData invitationData)
        {
            if (invitationData.DataStateManager.GetState(invitationData) == DataStateManagerState.Updated)
            {
                providerFactory.EstablishTransaction(transactionHandler, invitationData);
                using (IDbCommand command = transactionHandler.Connection.CreateCommand())
                {
                    command.CommandText = "vte.USP_Invitation";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transactionHandler.Transaction.InnerTransaction;

                    IDataParameter timestamp = Util.CreateParameter(providerFactory, "timestamp", DbType.DateTime);
                    timestamp.Direction = ParameterDirection.Output;
                    command.Parameters.Add(timestamp);

                    Util.AddParameter(providerFactory, command.Parameters, "id", DbType.Guid, Util.GetParameterValue(invitationData.InvitationId));
                    Util.AddParameter(providerFactory, command.Parameters, "invitee", DbType.String, Util.GetParameterValue(invitationData.Invitee));
                    Util.AddParameter(providerFactory, command.Parameters, "title", DbType.String, Util.GetParameterValue(invitationData.Title));
                    Util.AddParameter(providerFactory, command.Parameters, "note", DbType.String, Util.GetParameterValue(invitationData.Note));
                    Util.AddParameter(providerFactory, command.Parameters, "eventDate", DbType.Date, Util.GetParameterValue(invitationData.EventDate));
                    Util.AddParameter(providerFactory, command.Parameters, "rsvpDue", DbType.Date, Util.GetParameterValue(invitationData.RSVPDueDate));

                    command.ExecuteNonQuery();

                    invitationData.UpdateTimestamp = (DateTime)timestamp.Value;
                }
            }
        }
    }
}
