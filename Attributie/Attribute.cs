using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubPagesDemo.Attributie
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class CategorizedAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class SuspendAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class IconAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class AvatarAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ReportAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ExcelColumnAttribute : Attribute
    {
        public string? ColumnName { get;/* set; */}
        //public ExcelColumnAttribute() { }
        public ExcelColumnAttribute(string? columnName = null)
        {
            ColumnName = columnName;
        }
    }
}
