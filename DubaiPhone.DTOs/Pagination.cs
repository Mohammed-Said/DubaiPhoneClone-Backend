using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs
{
    public  class Pagination<T>
    {
       public T entity { get; set; }
       public int Count;
       public int Page;
       public int PageSize;
    }
}
