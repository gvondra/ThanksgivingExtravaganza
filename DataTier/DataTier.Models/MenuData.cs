using Vondra.DataTier.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.DataTier.Models
{
    public class MenuData : DataManagedStateBase<MenuData>
    {
        [ColumnMapping("MenuId", IsNullable = false)] public int MenuId { get; set; }
        [ColumnMapping("Title", IsNullable = false)] public string Title { get; set; }
        [ColumnMapping("Description", IsNullable = false)] public string Description { get; set; }
        [ColumnMapping("SortOrder", IsNullable = false)] public int SortOrder { get; set; }
        [ColumnMapping("CreateTimestamp", IsNullable = false)] public DateTime CreateTimestamp { get; set; }
        [ColumnMapping("UpdateTimestamp", IsNullable = false)] public DateTime UpdateTimestamp { get; set; }
    }
}
