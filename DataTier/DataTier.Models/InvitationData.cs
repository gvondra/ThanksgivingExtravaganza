using System;
using System.Collections.Generic;
using System.Text;
using Vondra.DataTier.Common;
namespace Vondra.Thanksgiving.Extravaganza.DataTier.Models
{
    public class InvitationData : DataManagedStateBase<InvitationData>
    {
        [ColumnMapping("InvitationId", IsNullable = false)] public Guid InvitationId { get; set; }
        [ColumnMapping("Invitee", IsNullable = false)] public string Invitee { get; set; }
        [ColumnMapping("Title", IsNullable = false)] public string Title { get; set; }
        [ColumnMapping("Note", IsNullable = false)] public string Note { get; set; }
        [ColumnMapping("EventDate", IsNullable = false)] public DateTime EventDate { get; set; }
        [ColumnMapping("RSVPDueDate", IsNullable = false)] public DateTime RSVPDueDate { get; set; }
        [ColumnMapping("CreateTimestamp", IsNullable = false)] public DateTime CreateTimestamp { get; set; }
        [ColumnMapping("UpdateTimestamp", IsNullable = false)] public DateTime UpdateTimestamp { get; set; }
    }
}
