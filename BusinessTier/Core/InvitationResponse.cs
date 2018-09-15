using System;
using System.Collections.Generic;
using System.Text;
using Vondra.Thanksgiving.Extravaganza.BusinessTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Client;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
using Vondra.Thanksgiving.Extravaganza.Framework;
namespace Vondra.Thanksgiving.Extravaganza.Core
{
    public class InvitationResponse : IInvitationResponse
    { 
        private InvitationResponseData m_responseData;
        private IInvitationResponseDataSaver m_responseDataSaver;
        private IInvitation m_invitation;

        public InvitationResponse(InvitationResponseData responseData,
            IInvitationResponseDataSaver responseDataSaver,
            IInvitation invitation)
        {
            m_responseData = responseData;
            m_responseDataSaver = responseDataSaver;
            m_invitation = invitation;
        }

        public int InvitationResponseId
        {
            get
            {
                return m_responseData.InvitationResponseId;
            }
        }

        private Guid InvitationId
        {
            get
            {
                return m_responseData.InvitationId;
            }
            set
            {
                m_responseData.InvitationId = value;
            }
        }

        public bool? IsAttending
        {
            get
            {
                return m_responseData.IsAttending;
            }
        }

        public short? AttendeeCount
        {
            get
            {
                return m_responseData.AttendeeCount;
            }
        }

        public string Note
        {
            get
            {
                return m_responseData.Note;
            }
        }

        public DateTime CreateTimestamp
        {
            get
            {
                return m_responseData.CreateTimestamp;
            }
        }

        public void Create(ITransactionHandler transactionHandler)
        {
            this.InvitationId = m_invitation.InvitationId;
            m_responseDataSaver.Create(new TransactionHandlerWrapper(transactionHandler), m_responseData);
        }
    }
}
