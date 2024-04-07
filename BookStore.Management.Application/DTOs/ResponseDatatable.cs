using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Application.DTOs
{
    public class ResponseDatatable<T>
    {
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set;}
        public int Draw { get; set; }
        public List<T> Data { get; set; }
    }
}
