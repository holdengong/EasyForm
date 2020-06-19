using EasyForm.Core.Models.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyForm.Core.Interfaces
{
    public interface IHasOptions
    {
        /// <summary>
        /// provide field options directly.
        /// </summary>
        IEnumerable<FieldOption> Options { get; set; }

        /// <summary>
        /// get options from a store at runtime, required if options is null.
        /// </summary>
        string OptionsProvider { get; set; }

        /// <summary>
        ///  /// <summary>
        /// get options from a store at runtime, required if options is null.
        /// </summary>
        /// </summary>
        IOptionsStore OptionsStore { get; set; }
    }
}
