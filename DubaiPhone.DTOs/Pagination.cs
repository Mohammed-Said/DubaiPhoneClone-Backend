using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs
{
    public class Pagination<T>
    {
        public T entity { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Stock { get; set; }
    }
}
