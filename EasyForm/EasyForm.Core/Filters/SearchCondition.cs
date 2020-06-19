using EasyForm.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace EasyForm.Core.Filters
{
    public class SearchCondition
    {
        public SearchCondition(int pageNo, int pageSize, IEnumerable<IRecordSorter> sorters)
        : this(pageNo, pageSize, null, sorters)
        {
        }

        public SearchCondition(int pageNo, int pageSize, IRecordFilter filter, IRecordSorter sorter)
           : this(pageNo, pageSize, filter, new List<IRecordSorter> { sorter })
        {
        }

        public SearchCondition(int pageNo, int pageSize, IRecordSorter sorter)
            : this(pageNo, pageSize, null, new List<IRecordSorter> { sorter })
        {
        }

        public SearchCondition(int pageNo, int pageSize, IRecordFilter filter, IEnumerable<IRecordSorter> sorters)
        {
            if (pageNo < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNo));
            }

            if (pageSize > EasyFormConsts.MAX_PAGE_SIZE)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            PageNo = pageNo;
            PageSize = pageSize;
            Filter = filter;
            Sorters = sorters;
        }

        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public IRecordFilter Filter { get; set; }
        public IEnumerable<IRecordSorter> Sorters { get; set; }
    }
}
