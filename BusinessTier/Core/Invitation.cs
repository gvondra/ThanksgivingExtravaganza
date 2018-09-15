using System;
using System.Collections.Generic;
using System.Text;
using Vondra.Thanksgiving.Extravaganza.BusinessTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Client;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
using Vondra.Thanksgiving.Extravaganza.Framework;
namespace Vondra.Thanksgiving.Extravaganza.Core
{
    public class Invitation : IInvitation
    {
        private InvitationData m_invitationData;
        private IInvitationDataSaver m_invitationDataSaver;
        private IInvitationResponseFactory m_responseFactory;

        public Invitation(InvitationData invitationData,
            IInvitationDataSaver invitationDataSaver,
            IInvitationResponseFactory responseFactory)
        {
            m_invitationData = invitationData;
            m_invitationDataSaver = invitationDataSaver;
            m_responseFactory = responseFactory;
        }

        public Guid InvitationId
        {
            get
            {
                return m_invitationData.InvitationId;
            }
        }

        public string Invitee
        {
            get
            {
                return m_invitationData.Invitee;
            }
            set
            {
                m_invitationData.Invitee = value;
            }
        }
        public string Title
        {
            get
            {
                return m_invitationData.Title;
            }
            set
            {
                m_invitationData.Title = value;
            }
        }
        public string Note
        {
            get
            {
                return m_invitationData.Note;
            }
            set
            {
                m_invitationData.Note = value;
            }
        }
        public DateTime EventDate
        {
            get
            {
                return m_invitationData.EventDate;
            }
            set
            {
                m_invitationData.EventDate = value;
            }
        }
        public DateTime RSVPDueDate
        {
            get
            {
                return m_invitationData.RSVPDueDate;
            }
            set
            {
                m_invitationData.RSVPDueDate = value;
            }
        }

        public DateTime CreateTimestamp
        {
            get
            {
                return m_invitationData.CreateTimestamp;
            }
        }

        public DateTime UpdateTimestamp
        {
            get
            {
                return m_invitationData.UpdateTimestamp;
            }
        }

        public void Create(ITransactionHandler transactionHandler)
        {
            m_invitationDataSaver.Create(new TransactionHandlerWrapper(transactionHandler), m_invitationData);
        }

        public IInvitationResponse CreateResponse(bool? isAttending, short? attendingCount, string note)
        {
            return m_responseFactory.Create(this, isAttending, attendingCount, note);
        }

        public IEnumerable<IInvitationResponse> GetResponses(ISettings settings)
        {
            return m_responseFactory.GetByInvitation(settings, this);
        }

        public void Update(ITransactionHandler transactionHandler)
        {
            m_invitationDataSaver.Update(new TransactionHandlerWrapper(transactionHandler), m_invitationData);
        }
    }
}
