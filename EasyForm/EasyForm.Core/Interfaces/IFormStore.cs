using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyForm.Core.Interfaces
{
    public interface IFormStore
    {
        Task<Form> FindFormByFormIdAsync(String formId);
    }
}
