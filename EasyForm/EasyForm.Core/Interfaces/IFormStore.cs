using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyForm.Core.Interfaces
{
    interface IFormStore
    {
        Task<Form> FindFormByIdAsync(String formId);
    }
}
