using EasyForm.Core.Models.Forms.Base;
using System.Collections.Generic;

namespace EasyForm.Core.Models.Definitions
{
    public class UploaderField : ObjectField<IEnumerable<File>>
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
