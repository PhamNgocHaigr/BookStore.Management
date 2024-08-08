using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Domain.Setting
{
    public class EmailSetting
    {
        public string To { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<string> CC { get; set; } = new List<string>();
        public List<string> AttachmentFiles { get; set; } = new List<string>();
    }
}
