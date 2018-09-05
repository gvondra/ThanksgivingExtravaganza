using Vondra.DataTier.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.DataTier.Models
{
    public class MenuCommentData : DataManagedStateBase<MenuCommentData>
    {
        [ColumnMapping("MenuCommentId", IsNullable = false)] public int MenuCommentId { get; set; }
        [ColumnMapping("MenuId", IsNullable = false)] public int MenuId { get; set; }
        [ColumnMapping("Text", IsNullable = false)] public string Text { get; set; }
        [ColumnMapping("CreateUser", IsNullable = false)] public string CreateUser { get; set; }
        [ColumnMapping("CreateTimestamp", IsNullable = false)] public DateTime CreateTimestamp { get; set; }        
    }
}
