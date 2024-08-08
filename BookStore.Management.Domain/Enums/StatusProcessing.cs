using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Domain.Enums
{
    public enum StatusProcessing
    {
        None = 0,
        New = 1,
        Processing = 2,
        Cancel = 3,
        Complete = 4
    }
}
