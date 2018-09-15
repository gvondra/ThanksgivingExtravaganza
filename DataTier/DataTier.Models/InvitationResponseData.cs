using System;
using System.Collections.Generic;
using System.Text;
using Vondra.DataTier.Common;
namespace Vondra.Thanksgiving.Extravaganza.DataTier.Models
{
    public class InvitationResponseData : DataManagedStateBase<InvitationResponseData>
    {
        [ColumnMapping("InvitationResponseId", IsNullable = false)] public int InvitationResponseId { get; set; }
        [ColumnMapping("InvitationId", IsNullable = false)] public Guid InvitationId { get; set; }
        [ColumnMapping("IsAttending", IsNullable = true)] public bool? IsAttending { get; set; }
        [ColumnMapping("AttendeeCount", IsNullable = true)] public short? AttendeeCount { get; set; }
        [ColumnMapping("Note", IsNullable = false)] public string Note { get; set; }
        [ColumnMapping("CreateTimestamp", IsNullable = false)] public  DateTime CreateTimestamp { get; set; }
    }
}
