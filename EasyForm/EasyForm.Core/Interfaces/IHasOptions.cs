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
        IEnumerable<Option> Options { get; set; }

        /// <summary>
        /// func to get options, input purpose,output options.
        /// </summary>
        Func<string, IEnumerable<Option>> OptionsFunc { get; set; }
    }
}
