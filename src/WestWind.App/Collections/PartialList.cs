using System.Collections.Generic;

namespace WestWind.App.Collections
{
    public class PartialList<T>
    {
        public readonly int TotalCount;
        public List<T> Items {get; set;}
        public PartialList(int totalCount, List<T> items)
        {
            TotalCount = totalCount;
            Items = items;
        }
    }
}