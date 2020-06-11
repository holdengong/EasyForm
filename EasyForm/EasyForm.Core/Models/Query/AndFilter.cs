using EasyForm.Core.Interfaces;
namespace EasyForm.Core.Models.Query
{
    public class AndFilter : IRecordFilter
    {
        private readonly IRecordFilter[] _filters;
        public AndFilter(params IRecordFilter[] filters)
        {
            _filters = filters;
        }
    }
}
