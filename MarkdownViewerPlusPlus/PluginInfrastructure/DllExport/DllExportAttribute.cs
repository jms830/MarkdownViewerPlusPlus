// NPP plugin platform for .Net v0.94.00 by Kasper B. Graversen etc.
// Modified to use 3F/DllExport which fixes NaN IL assembler issues
using System;
using System.Runtime.InteropServices;

namespace RGiesecke.DllExport
{
    /// <summary>
    /// The fully qualified type name must be <c>RGiesecke.DllExport.DllExportAttribute</c> in order to work with 3F/DllExport.
    /// This local implementation avoids a runtime reference to DllExport.dll which would be copied to output.
    /// <para>
    /// 3F/DllExport uses a modified IL Assembler that correctly handles double.NaN values which caused
    /// "syntax error at token '-' in: IL_0008: ldc.r8 -nan(ind)" errors with other DllExport implementations.
    /// See <seealso href="https://github.com/3F/DllExport"/>
    /// </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    partial class DllExportAttribute : Attribute
    {
        public DllExportAttribute()
        {
        }

        public DllExportAttribute(string exportName)
            : this(exportName, CallingConvention.StdCall)
        {
        }

        public DllExportAttribute(string exportName, CallingConvention callingConvention)
        {
            ExportName = exportName;
            CallingConvention = callingConvention;
        }

        public CallingConvention CallingConvention { get; set; }

        public string ExportName { get; set; }
    }
}