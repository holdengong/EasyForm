using EasyForm.Core.Interfaces;
namespace EasyForm.Core.Models.Query
{
    public class OrFilter : IRecordFilter
    {
        private readonly IRecordFilter[] _filters;
        public OrFilter(params IRecordFilter[] filters)
        {
            _filters = filters;
        }
    }
}
