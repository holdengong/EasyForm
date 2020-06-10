using EasyForm.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.Core.Interfaces
{
    public interface IFieldHasOptions
    {
        /// <summary>
        /// provide field options directly.
        /// </summary>
        IEnumerable<FieldOption> Options { get; set; }

        /// <summary>
        /// get options from a store at runtime, required if options is null.
        /// </summary>
        string FieldOptionsName { get; set; }

        /// <summary>
        ///  /// <summary>
        /// get options from a store at runtime, required if options is null.
        /// </summary>
        /// </summary>
        IFieldOptionsStore FieldOptionsStore { get; set; }
    }
}
