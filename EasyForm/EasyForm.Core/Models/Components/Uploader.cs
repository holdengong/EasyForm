using EasyForm.Core.Models.Abstract;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Components
{
    public class Uploader : ArrayField<object>
    {
        /// <summary>
        /// if allow upload multiple files,default false
        /// </summary>
        public bool IsMultiple { get; set; }

        /// <summary>
        /// file types allowed to upload
        /// </summary>
        public IEnumerable<string> AllowFileTypes { get; set; }

        /// <summary>
        /// file count allowed to upload
        /// </summary>
        public int CountLimit { get; set; }

        /// <summary>
        /// file size allowed to upload (kb)
        /// </summary>
        public long SizeLimit { get; set; }
    }
}
