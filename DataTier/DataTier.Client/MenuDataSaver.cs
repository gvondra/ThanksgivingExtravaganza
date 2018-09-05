using System;
using System.Collections.Generic;
using System.Data;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;

namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public class MenuDataSaver : IMenuDataSaver
    {
        public void Create(ITransactionHandler transactionHandler, MenuData menuData)
        {
            Create(transactionHandler, new DbProviderFactory(), menuData);
        }

        public void Create(ITransactionHandler transactionHandler, IDbProviderFactory providerFactory, MenuData menuData)
        {
            if (menuData.DataStateManager.GetState(menuData) == DataStateManagerState.New)
            {
                providerFactory.EstablishTransaction(transactionHandler, menuData);
                using (IDbCommand command = transactionHandler.Connection.CreateCommand())
                {
                    command.CommandText = "vte.ISP_Menu";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transactionHandler.Transaction.InnerTransaction;

                    IDataParameter id = Util.CreateParameter(providerFactory, "id", DbType.Int32);
                    id.Direction = ParameterDirection.Output;
                    command.Parameters.Add(id);

                    IDataParameter timestamp = Util.CreateParameter(providerFactory, "timestamp", DbType.DateTime);
                    timestamp.Direction = ParameterDirection.Output;
                    command.Parameters.Add(timestamp);

                    Util.AddParameter(providerFactory, command.Parameters, "title", DbType.String, Util.GetParameterValue(menuData.Title));
                    Util.AddParameter(providerFactory, command.Parameters, "description", DbType.String, Util.GetParameterValue(menuData.Description));
                    Util.AddParameter(providerFactory, command.Parameters, "sortOrder", DbType.Int32, Util.GetParameterValue(menuData.SortOrder));

                    command.ExecuteNonQuery();

                    menuData.MenuId = (int)id.Value;
                    menuData.CreateTimestamp = (DateTime)timestamp.Value;
                    menuData.UpdateTimestamp = (DateTime)timestamp.Value;
                }
            }            
        }

        public void Delete(ITransactionHandler transactionHandler, int id)
        {
            Delete(transactionHandler, new DbProviderFactory(), id);
        }

        public void Delete(ITransactionHandler transactionHandler, IDbProviderFactory providerFactory, int id)
        {
            providerFactory.EstablishTransaction(transactionHandler);
            using (IDbCommand command = transactionHandler.Connection.CreateCommand())
            {
                command.CommandText = "vte.DSP_Menu";
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transactionHandler.Transaction.InnerTransaction;

                Util.AddParameter(providerFactory, command.Parameters, "id", DbType.Int32, Util.GetParameterValue(id));

                command.ExecuteNonQuery();
            }
        }

        public void Update(ITransactionHandler transactionHandler, MenuData menuData)
        {
            Update(transactionHandler, new DbProviderFactory(), menuData);
        }

        public void Update(ITransactionHandler transactionHandler, IDbProviderFactory providerFactory, MenuData menuData)
        {
            if (menuData.DataStateManager.GetState(menuData) == DataStateManagerState.Updated)
            {
                providerFactory.EstablishTransaction(transactionHandler, menuData);
                using (IDbCommand command = transactionHandler.Connection.CreateCommand())
                {
                    command.CommandText = "vte.USP_Menu";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transactionHandler.Transaction.InnerTransaction;

                    IDataParameter timestamp = Util.CreateParameter(providerFactory, "timestamp", DbType.DateTime);
                    timestamp.Direction = ParameterDirection.Output;
                    command.Parameters.Add(timestamp);

                    Util.AddParameter(providerFactory, command.Parameters, "id", DbType.Int32, Util.GetParameterValue(menuData.MenuId));
                    Util.AddParameter(providerFactory, command.Parameters, "title", DbType.String, Util.GetParameterValue(menuData.Title));
                    Util.AddParameter(providerFactory, command.Parameters, "description", DbType.String, Util.GetParameterValue(menuData.Description));
                    Util.AddParameter(providerFactory, command.Parameters, "sortOrder", DbType.Int32, Util.GetParameterValue(menuData.SortOrder));

                    command.ExecuteNonQuery();

                    menuData.UpdateTimestamp = (DateTime)timestamp.Value;
                }
            }            
        }
    }
}
